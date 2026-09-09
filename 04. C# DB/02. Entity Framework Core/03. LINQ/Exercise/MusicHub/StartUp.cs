namespace MusicHub;

using Data;
using Initializer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        DbInitializer.ResetDatabase(context);

        //Console.WriteLine(ExportAlbumsInfo(context, 9)); 
        Console.WriteLine(ExportSongsAboveDuration(context, 4));
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        var albums = context.Albums
            .AsNoTracking()
            .Include(a => a.Songs)
            .Where(a => a.ProducerId == producerId)
            .Select(a => new
            {
                a.Name,
                a.ReleaseDate,
                ProducerName = a.Producer.Name,
                a.Price,
                Songs = a.Songs.Select(s => new
                {
                    s.Name,
                    s.Price,
                    WriterName = s.Writer.Name
                })
                .OrderByDescending(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToArray()
            })
            .ToArray()
            .OrderByDescending(a => a.Price);

        StringBuilder sb = new();
        foreach (var a in albums)
        {
            sb.AppendLine($"-AlbumName: {a.Name}")
              .AppendLine($"-ReleaseDate: {a.ReleaseDate.ToString("MM/dd/yyyy")}")
              .AppendLine($"-ProducerName: {a.ProducerName}")
              .AppendLine("-Songs:");

            int i = 0;
            foreach (var s in a.Songs)
            {
                i++;
                sb.AppendLine($"---#{i}")
                  .AppendLine($"---SongName: {s.Name}")
                  .AppendLine($"---Price: {s.Price:F2}")
                  .AppendLine($"---Writer: {s.WriterName}");
            }

            sb.AppendLine($"-AlbumPrice: {a.Price:F2}");
        }

        return sb.ToString().Trim();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        TimeSpan targetDuration = TimeSpan.FromSeconds(duration);

        var songs = context.Songs
            .TagWith("MYQERRY")
            .AsNoTracking()
            .Where(s => s.Duration > targetDuration)
            .Select(s => new
            {
                s.Name,
                Writer = s.Writer.Name,
                AlbumProducer = s.Album.Producer.Name,
                s.Duration,
                SongPerformers = s.SongPerformers.Select(sp => new
                {
                    sp.Performer.FirstName,
                    sp.Performer.LastName,
                })
                .ToArray()
            })
            .OrderBy(s => s.Name)
            .ThenBy(s => s.Writer)
            .ToArray();

        StringBuilder sb = new();
        int i = 0;
        foreach (var s in songs)
        {
            sb.AppendLine($"-Song #{++i}")
              .AppendLine($"---SongName: {s.Name}")
              .AppendLine($"---Writer: {s.Writer}");

            foreach (var sp in s.SongPerformers.OrderBy(sp => $"{sp.FirstName} {sp.LastName}"))
                sb.AppendLine($"---Performer: {sp.FirstName} {sp.LastName}");

            sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}")
              .AppendLine($"---Duration: {s.Duration.ToString("c")}");
        }

        return sb.ToString().Trim();
    }
}
