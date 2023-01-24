using System;

namespace SequentialGuid
{
    /// <summary>
    /// Generate Guids in Sequential order
    /// First Guid will be 00000000-0000-0000-0000-000000000001
    /// Use Set Seed to Seed First Guid
    /// Prefered Way to do :
    /// <code>
    ///     SetSeed(Guid.NewGuid());
    /// </code>
    /// </summary>
    public static class GuidInstance
    {
        private static int[]? _sqlOrderMap;
        private static int[] SqlOrderMap
        {
            get
            {
                _sqlOrderMap ??= new int[16] {
                    3, 2, 1, 0, 5, 4, 7, 6, 9, 8, 15, 14, 13, 12, 11, 10
                };
                return _sqlOrderMap;
            }
        }

        private static Guid _currentGuid;
        static GuidInstance()
        {
            _currentGuid = new Guid("00000000-0000-0000-0000-000000000001");
        }
        /// <summary>
        /// Set Starting Point for Guid Generation
        /// </summary>
        /// <param name="guid"></param>
        public static void SetSeed(Guid guid)
        {
            _currentGuid = new Guid(guid.ToByteArray());
        }
        /// <summary>
        /// Returns Current Guid (Last Generated)
        /// </summary>
        /// <returns>Current Guid</returns>
        public static Guid GetCurrentGuid()
        {
            return _currentGuid;
        }
        /// <summary>
        /// Generate Next Guid
        /// </summary>
        /// <returns>Next Guid</returns>
        public static Guid Next()
        {
            byte[] bytes = _currentGuid.ToByteArray();
            for (int mapIndex = 0; mapIndex < 16; mapIndex++)
            {
                int bytesIndex = SqlOrderMap[mapIndex];
                bytes[bytesIndex]++;
                if (bytes[bytesIndex] != 0)
                {
                    break; // No need to increment more significant bytes
                }
            }
            _currentGuid = new Guid(bytes);
            return _currentGuid;
        }
    }
}
