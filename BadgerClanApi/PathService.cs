using System.Xml.XPath;
using BadgerClanApi.Pathing;

namespace BadgerClanApi
{
    public class PathService 
    {
        private readonly Dictionary<string, IPath> _paths;
        IPath _currentPath;

        public PathService(IEnumerable<IPath> paths)
        {
            _paths = paths.ToDictionary(s => s.GetType().Name); ;

            _currentPath = _paths["RunAndGun"];
        }

        public IPath GetPathing()
        {
            return _currentPath;
        }

        public void SetPathing(string requestedStrategy)
        {
            if (_paths.TryGetValue(requestedStrategy.ToString(), out var strategy))
            {
                _currentPath = strategy;
            }
        }
    }
}
