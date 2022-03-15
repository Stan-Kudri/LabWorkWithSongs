namespace LabWorkWithSongs
{
    public class Song
    {
        private readonly string _name;
        private readonly string _author;

        public Song PastSong
        {
            get { return PastSong; }
            set
            {
                Equals(value);
                PastSong = value;
            }
        }

        public Song(string name, string author)
        {
            _name = name;
            _author = author;
        }


        public void PrintSong()
        {
            Console.WriteLine(Title());
        }

        public string Title() => String.Format($"{_author} - {_name}");

        public bool Equals(Song? song)
        {
            return song != null && song._author == _author && song._name == _name;
        }

        public override string ToString()
        {
            return String.Format($"{_author} - {_name}");
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return Equals(obj as Song);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_author, _name);
        }
    }
}
