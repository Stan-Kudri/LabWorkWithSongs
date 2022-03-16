namespace LabWorkWithSongs
{
    public class Song
    {
        private readonly string _name;
        private readonly string _author;
        private readonly Song? _previous;

        public string Name => _name;

        public string Author => _author;

        public string Title => $"{_author} - {_name}";

        public Song? Previous => _previous;

        public Song(string name, string author) : this(name, author, null)
        {
        }

        public Song(string name, string author, Song? pastSong = null)
        {
            _name = name;
            _author = author;
            _previous = pastSong;
        }

        public void PrintSong()
        {
            Console.WriteLine(Title);
        }

        public bool Equals(Song? song)
        {
            return song != null && song._author == _author && song._name == _name;
        }

        public override string ToString()
        {
            return Title;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            return Equals(obj as Song);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_author, _name);
        }
    }
}
