namespace _10._SoftUni_Course_Planning
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> courses = Console.ReadLine()
				.Split(", ")
				.ToList();

			string command;
			while ((command = Console.ReadLine()) != "course start")
			{
				string[] input = command.Split(':');

				switch (input[0])
				{
					case "Add": AddCourse(courses, input[1]); break;
					case "Insert": Insert(courses, input[1], int.Parse(input[2])); break;
					case "Remove": Remove(courses, input[1]); break;
					case "Swap": Swap(courses, input[1], input[2]); break;
					case "Exercise": AddExercise(courses, input[1]); break;
				}
			}

			for (int i = 0; i < courses.Count; i++)
			{
				Console.WriteLine($"{i + 1}.{courses[i]}");
			}
		}

		private static void AddExercise(List<string> courses, string course)
		{
			if (!IsCourseExists(courses, course))
			{
				courses.Add(course);
				courses.Add($"{course}-Exercise");
				return;
			}

			if (IsCourseExists(courses, course))
			{
				int courseIndex = courses.IndexOf(course);
				if (!IsExerciseExists(courses, course))
				{
					courses.Insert(courseIndex + 1, $"{course}-Exercise");
				}
				return;
			}
		}

		private static void Swap(List<string> courses, string course1, string course2)
		{
			if (IsCourseExists(courses, course1) && IsCourseExists(courses, course2))
			{
				int course1Index = courses.IndexOf(course1);
				int course2Index = courses.IndexOf(course2);

				bool course1HasExercise = IsExerciseExists(courses, course1);
				bool course2HasExercise = IsExerciseExists(courses, course2);

				courses[course1Index] = course2;
				if (course2HasExercise)
				{
					courses.RemoveAt(course2Index + 1);
					courses.Insert(course1Index + 1, $"{course2}-Exercise");
					course2Index++;
				}

				courses[course2Index] = course1;
				if (course1HasExercise)
				{
					courses.RemoveAt(course1Index + 1);
					courses.Insert(course2Index + 1, $"{course1}-Exercise");
				}
			}
		}

		private static void Remove(List<string> courses, string course)
		{
			courses.Remove(course);
		}

		private static void Insert(List<string> courses, string course, int index)
		{
			if (!IsCourseExists(courses, course))
			{
				courses.Insert(index, course);
			}
		}

		private static void AddCourse(List<string> courses, string course)
		{
			if (!IsCourseExists(courses, course))
			{
				courses.Add(course);
			}
		}

		private static bool IsCourseExists(List<string> courses, string course)
		{
			return courses.Contains(course);
		}

		private static bool IsExerciseExists(List<string> courses, string course)
		{
			return courses.Contains($"{course}-Exercise");
		}
	}
}
