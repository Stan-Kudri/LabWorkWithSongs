using System.Collections;

namespace LabWorkWithSongs
{
    public class SongEnumerator : IEnumerator<Song>
    {
        private Song _current;
        private Song? _initial;

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
            if (_initial == null)
            {
                _initial = _current;
                return true;
            }
            if (_current.Previous == null)
                return false;
            _current = _current.Previous;
            return true;
        }

        public void Reset()
        {
            if (_initial != null)
                _current = _initial;
        }
    }
}
