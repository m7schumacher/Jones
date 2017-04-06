using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Internal.Tags
{
    public class TagCollection
    {
        public string Root { get; set; }
        public List<Tag> Tags { get; set; }

        public TagCollection(string root)
        {
            Root = root;
            Tags = new List<Tag>();
        }

        public TagCollection(string root, List<Tag> tags) : this(root)
        {
            Tags = tags;
        }

        public Tag this[string path]
        {
            get
            {
                return GetTagByPath(path);
            }
        }

        public List<Tag> MatchByAdjective(string adjective)
        {
            return Tags.Where(tg => tg.Adjectives.Contains(adjective)).ToList();
        }

        public void Combine(TagCollection collection)
        {
            Tags.AddRange(collection.Tags);
        }

        public bool ContainsPath(string path)
        {
            return Tags.Any(tg => tg.Path.Equals(path));
        }

        public Tag GetTagByPath(string path)
        {
            return Tags.FirstOrDefault(tg => tg.Path.Equals(path));
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} tags", Root, Tags.Count);
        }
    }
}
