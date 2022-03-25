using System.Collections;

namespace LabWorkWithSongs
{
    public class SongEnumerator : IEnumerator<Song>
    {
        private Song _current;

        public SongEnumerator(Song song)
        {
            _current = song;
        }

        public Song Current => _current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current.Previous == null)
                return false;
            _current = _current.Previous;
            return true;
        }

        public void Reset()
        {
        }
    }
}
