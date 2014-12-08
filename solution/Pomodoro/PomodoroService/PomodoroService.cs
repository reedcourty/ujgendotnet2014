using PomodoroDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PomodoroService
{
    public class PomodoroService : IPomodoroService
    {
        public List<Tag> GetTags()
        {
            Tag tag_test_001 = new Tag() { TagName = "Test 001" };
            Tag tag_test_002 = new PomodoroTag() { TagName = "Test 002", CreatedAt = DateTime.UtcNow };
            Tag tag_test_003 = new ProjectTag() { TagName = "Test 003", CreatedAt = DateTime.UtcNow, Priority = 1 };

            List<Tag> tags = new List<Tag>();
            tags.Add(tag_test_001);
            tags.Add(tag_test_002);
            tags.Add(tag_test_003);

            return tags;
        }
    }
}
