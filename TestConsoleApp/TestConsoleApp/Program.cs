static string GenColumnKeyData(int length, int index)
{
    string data = "";
    string indexStr = $"00000{index}";
    length = length >= 8 ? 6 : length;

    if (length >= 5)
    {
        int startIndex = indexStr.Length - length + 3;
        string rightSubstring = indexStr.Substring(startIndex);
        data += "key" + rightSubstring;
    }
    else
    {
        int startIndex = indexStr.Length - length;
        data = indexStr.Substring(startIndex);
    }

    return data;
}

var xx = GenColumnKeyData(20, 12);
Console.WriteLine(xx);