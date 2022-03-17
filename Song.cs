namespace LabWorkWithSongs
{
    public class Song
    {
        private readonly string _name;
        private readonly string _author;
        private readonly Song? _previous;
        List<string> _artist;


        public string Name => _name;

        public string Author => _author;

        public string Title => _artist.Count > 0 ?
                    string.Format($"{_author} - {_name} feat {string.Join('&', _artist)}") :
                    $"{_author} - {_name}";

        public Song? Previous => _previous;

        public Song(string name, string author) : this(name, author, null)
        {
        }

        public Song(string name, string author, Song? pastSong = null)
        {
            _name = name;
            _author = author;
            _previous = pastSong;
            _artist = new List<string>();
        }

        public Song WithFeature(string artist)
        {
            if (artist == null)
                throw new ArgumentNullException(nameof(artist));
            _artist.Add(artist);
            return this;
        }

        public void PrintSong()
        {
            Console.WriteLine(Title);
        }

        public bool EqualSongsByArtist(Song? song)
        {
            if (_artist == null)
                return Equals(song);
            else
            {
                return song != null && song.Name == _name;
            }
        }

        private bool Equals(Song? song)
        {
            if (_artist.Count == song._artist.Count)
                return song != null && song._author == _author && song._name == _name;
            return false;
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
            return HashCode.Combine(_author, _name, _previous, _artist);
        }
    }
}
