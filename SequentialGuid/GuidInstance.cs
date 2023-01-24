using System;

namespace SequentialGuid
{
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
        public static void SetSeed(Guid guid)
        {
            _currentGuid = new Guid(guid.ToByteArray());
        }
        public static Guid GetCurrentGuid()
        {
            return _currentGuid;
        }
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
