using System;
using System.Collections.Generic;
using System.Linq;

namespace Ch10_LINQ
{
    class Course
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public int Number { get; set; }
        public DateTime PublicationData { get; set; }
        public TimeSpan Duration { get; set; }
        public static readonly Course[] catalog =
        {
            new Course
            {
                Title = "Elements of geometry",
                Category = "MAT", Number = 101, Duration = TimeSpan.FromHours(3),
                PublicationData = new DateTime(2009, 5, 20)
            },
            new Course
            {
                Title = "Squaring the circle",
                Category = "MAT", Number = 102, Duration = TimeSpan.FromHours(7),
                PublicationData = new DateTime(2009, 4, 1)
            },
            new Course
            {
                Title = "Recreational organ Transplantation",
                Category = "BIO", Number = 305, Duration = TimeSpan.FromHours(4),
                PublicationData = new DateTime(2002, 7, 19)
            },
            new Course
            {
                Title = "hyperbolic geometry",
                Category = "MAT", Number = 207, Duration = TimeSpan.FromHours(5),
                PublicationData = new DateTime(2007, 10, 5)
            },
            new Course
            {
                Title = "OverSimplified data structures for demos",
                Category = "CSE", Number = 104 , Duration = TimeSpan.FromHours(2),
                PublicationData = new DateTime(2012, 2, 21)
            },
            new Course
            {
                Title = "Introduction to human anatomy and physiology",
                Category = "BIO", Number = 201, Duration = TimeSpan.FromHours(12),
                PublicationData = new DateTime(2001, 4, 11)
            }
        };

        public static void Example_Where()
        {
            var p = Course.catalog.Where((course, index) => (index % 2 == 0) && course.Duration.TotalHours >= 3);
            foreach (Course c in p)
            {
                Console.WriteLine(c.Title);
            }
        }
        public static void Example_OfType()
        {
            IEnumerable<object> instances = new object[] { -2, 0, "Hello", 1.23, true, "Han", "Hong" };
            var strings = instances.OfType<string>();
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
        }
        public static void Example_Select()
        {
            IEnumerable<string> nonIntro = Course.catalog.Select((course, MyNum) =>
                string.Format("Course {0}:{1}", MyNum, course.Title));
            Console.WriteLine("nonIntro:");
            foreach (string s in nonIntro)
            {
                Console.WriteLine(s);
            }
            //IEnumerable<string> nonIntro2 = Course.catalog.Where(c => c.Number >= 200)/*这个Where会触发CustomDefferedProvider的Where方法，本地的扩展方法*/
            //    .Select((course, index) => string.Format("Course {0}:{1}", index, course.Title));
            //Console.WriteLine("nonIntro2:");
            //foreach (string s in nonIntro2)
            //{
            //    Console.WriteLine(s);
            //}
        }
        public static void Example_Anonymous()
        {
            var result = Course.catalog.Select((course, index) => new { course, index })
                .Where(c => c.course.Number > 200)
                .Select(c => string.Format("Course {0}:{1}", c.index, c.course.Title));
            foreach (var e in result)
            {
                Console.WriteLine(e);
            }
        }

        public static void Example_Ordering()
        {
            //var q = from course in Course.catalog
            //        orderby course.Duration descending, course.PublicationData ascending
            //        select course;

            var q = Course.catalog.OrderBy(course => course.PublicationData).ThenByDescending(course => course.Duration);
            foreach (var c in q)
            {
                Console.WriteLine("Course:{0}  Publication:{1} Duration:{2}", c.Title, c.PublicationData, c.Duration);
            }
            //Console.WriteLine("Single:" + q.Single().Title); //Error
            //Console.WriteLine("Single:" + q.Single(course => course.Number == 101).Title);
            //Console.WriteLine("Single:", q.SingleOrDefault());//Error
            Console.WriteLine("First:", q.FirstOrDefault());
        }
        public static void Example_Ordering_First()
        {
            var q = Course.catalog.OrderBy(course => course.PublicationData);
            foreach (var c in q)
            {
                Console.WriteLine("Course:{0}  Publication:{1} Duration:{2}", c.Title, c.PublicationData, c.Duration);
            }
            Course c1 = q.FirstOrDefault();
            Console.WriteLine("First:" + c1.Title);
            Course c2 = q.LastOrDefault();
            Console.WriteLine("Last:" + c2.Title);
        }

        public static void Example_Ordering_ElementAt()
        {
            var q = Course.catalog.OrderBy(course => course.PublicationData);
            foreach (var c in q)
            {
                Console.WriteLine("Course:{0}  Publication:{1} Duration:{2}", c.Title, c.PublicationData, c.Duration);
            }
            Console.WriteLine("ElementAt:" + q.ElementAt(2).Title);
        }

        public static void Example_Ordering_ElementAt2()
        {
            var q = Course.catalog.Where(c => c.Category == "MAT");
            for(int i = 0; i < q.Count(); ++i)
            {
                //Never do this!
                Course c = q.ElementAt(i);
                Console.WriteLine(i.ToString() + c.Title);
            }
        }
        
        public static void Example_Zip()
        {
            string[] firstNames = {"Ian", "Arthur", "Arthur"};
            string[] lastNames = { "Griffiths", "Dent", "Pewty" };
            IEnumerable<string> fullNames = firstNames.Zip(lastNames, (first, last) => first + " " + last);
            foreach(string fullName in fullNames)
            {
                Console.WriteLine(fullName);
            }
        }

        public static void Example_Group()
        {
            //var subjectGroups = from course in Course.catalog
            //                    group course by course.Category;
            var subjectGroups = Course.catalog.GroupBy(course => course.Category);
            Console.WriteLine("subjectGroups type:" + subjectGroups.GetType().ToString());
            foreach(var group in subjectGroups)
            {
                Console.WriteLine("Category:" + group.Key);
                Console.WriteLine();
                foreach(var course in group)
                {
                    Console.WriteLine(course.Title);
                }
                Console.WriteLine();
            }
        }

        public static void Example_Group2()
        {
            //var subjectGroups = from course in Course.catalog
            //                    group course.Title by course.Category;
            var subjectGroups = Course.catalog
                .GroupBy(course => course.Category, course => course.Title);
            Console.WriteLine("subjectGroups type:" + subjectGroups.GetType().ToString());
            foreach (var group in subjectGroups)
            {
                Console.WriteLine("Category:" + group.Key);
                Console.WriteLine();
                foreach (var title in group)
                {
                    Console.WriteLine(title);
                }
                Console.WriteLine();
            }
        }

        public static void Example_Group_Into()
        {
            //var subjectGroups = from course in Course.catalog
            //                    group course by course.Category into category
            //                    select string.Format("Category '{0}' contains {1} courses",
            //                    category.Key, category.Count());
            //var subjectGroups = Course.catalog.GroupBy(course => course.Category)
            IEnumerable<string> subjectGroups = Course.catalog.GroupBy(course => course.Category,
                                                (category, courses) => string.Format("Category '{0}' contains {1} courses",
                                                category, courses.Count()));
            Console.WriteLine("subjectGroups type:" + subjectGroups.GetType().ToString());
            foreach (var group in subjectGroups)
            {
                Console.WriteLine(group);
            }
        }

        public static void Example_Group_Composite()
        {
            var bySubjectAndYear = from course in Course.catalog
                                   group course by new { course.Category, course.PublicationData.Year};
            foreach(var group in bySubjectAndYear)
            {
                Console.WriteLine("{0} {1}", group.Key.Category, group.Key.Year);
                foreach(var course in group)
                {
                    Console.WriteLine(course.Title);
                }
            }
            Console.WriteLine();
        }

        public static void Example_Join()
        {
            CourseChoice[] choices =
            {
                new CourseChoice {StudentId = 1, Category = "MAT", Number = 101 },
                new CourseChoice {StudentId = 1, Category = "MAT", Number = 102 },
                new CourseChoice {StudentId = 1, Category = "MAT", Number = 207 },

                new CourseChoice {StudentId = 2, Category = "MAT", Number = 101 },
                new CourseChoice {StudentId = 2, Category = "BIO", Number = 201 }
            };
            var studentAndCourses = from choice in choices
                                    join course in Course.catalog
                                    on new { choice.Category, choice.Number }
                                    equals new { course.Category, course.Number }
                                    select new { choice.StudentId, course };
            foreach(var item in studentAndCourses)
            {
                Console.WriteLine("StudentId({0}) will atten {1}!", item.StudentId, item.course.Title);
            }
        }

        public static void Example_Join2()
        {
            CourseChoice[] choices =
            {
                new CourseChoice {StudentId = 1, Category = "MAT", Number = 101 },
                new CourseChoice {StudentId = 1, Category = "MAT", Number = 102 },
                new CourseChoice {StudentId = 1, Category = "MAT", Number = 207 },

                new CourseChoice {StudentId = 2, Category = "MAT", Number = 101 },
                new CourseChoice {StudentId = 2, Category = "BIO", Number = 201 }
            };
            var studentAndCourses = from choice in choices
                                    join course in Course.catalog
                                    on new { choice.Category, choice.Number }
                                    equals new { course.Category, course.Number } into courses
                                    select new { choice.StudentId, Courses = courses};
            foreach (var item in studentAndCourses)
            {
                Console.WriteLine("StudentId({0}) will atten {1}!", item.StudentId, 
                    string.Join(",", item.Courses.Select(course => course.Title)));
            }
        }

        public static void Example_Conversion()
        {
            IEnumerable<object> sequence = Course.catalog.Select(c => (object)c);
            //IEnumerable<Course> courseSequence = (IEnumerable<Course>)sequence;

            //IEnumerable<Course> sequence = Course.catalog.Select(c => c);
            //IEnumerable<object> objectSequence = (IEnumerable<object>)sequence;
            var courseSequence = sequence.Cast<Course>();
            Console.WriteLine("courseSequence type:" + courseSequence.GetType().ToString());
        }

        public static void Example_Lookup()
        {
            ILookup<string, Course> categoryLookup = Course.catalog.ToLookup(course => course.Category);
            foreach (var item in categoryLookup["MAT"])
            {
                Console.WriteLine(item.Title);
            }
        }

        public static void Example_Dictionary()
        {
            var categoryDictionary = Course.catalog.ToDictionary(course => new { course.Category, course.Number });
            foreach (var item in categoryDictionary)
            {
                Console.WriteLine("Key.Category:{0} Key.Number:{1} Value:{2}", 
                    item.Key.Category, item.Key.Number, item.Value.Title);
            }
            Console.WriteLine();
            Console.WriteLine("Category='MAT',Number=101, course title:{0}", 
                categoryDictionary[new { Category = "MAT", Number = 101}].Title);
        }
    }

    public class CourseChoice
    {
        public int StudentId { get; set; }
        public string Category { get; set; }
        public int Number { get; set; }
    }
}
