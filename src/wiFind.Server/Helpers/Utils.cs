namespace wiFind.Server.Helpers
{
    public class Utils
    {
        // Purely for Migration Data Seed
        public static byte[] VarBinStrToBinaryArray(string varBinStr)
        {
            List<byte> byteList = new List<byte>();

            string hexPart = varBinStr.Substring(2);
            for (int i = 0; i < hexPart.Length / 2; i++)
            {
                string hexNumber = hexPart.Substring(i * 2, 2);
                byteList.Add((byte)Convert.ToInt32(hexNumber, 16));
            }

            return byteList.ToArray();
        }
    }
}
