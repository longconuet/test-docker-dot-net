// Chuỗi đầu vào
using System.Text;
using System.Text.RegularExpressions;

//string inputString = @"<拠点コード, varchar(7),>
//<管理キー, varchar(16),>
//<予定枝番, varchar(4),>
//<実績枝番, varchar(4),>
//<データ作成日, varchar(8),>";

//// Biểu thức chính quy
//string pattern = @"<(.*?),\s*(.*?),>";

//// Sử dụng Regex.Matches để tìm kiếm tất cả các kết quả
//MatchCollection matches = Regex.Matches(inputString, pattern);

//// Kiểm tra xem có kết quả nào không
//if (matches.Count > 0)
//{
//    foreach (Match match in matches)
//    {
//        string fieldName = match.Groups[1].Value;
//        string dataType = match.Groups[2].Value;

//        Console.WriteLine("Tên trường: " + fieldName);
//        Console.WriteLine("Kiểu dữ liệu: " + dataType);
//        Console.WriteLine("---------------");
//    }
//}
//else
//{
//    Console.WriteLine("Không tìm thấy kết quả phù hợp.");
//}

// Chuỗi đầu vào
//string inputString = @"<拠点コード, varchar(7),>
//<管理キー, varchar(16),>
//<予定枝番, varchar(4),>
//<実績枝番, varchar(4),>
//<データ作成日, varchar(8),>";

//// Biểu thức chính quy
//string pattern = @"<(.*?),\s*(varchar)\((\d+)\),>";

//// Sử dụng Regex.Matches để tìm kiếm tất cả các kết quả
//MatchCollection matches = Regex.Matches(inputString, pattern);

//// Kiểm tra xem có kết quả nào không
//if (matches.Count > 0)
//{
//    foreach (Match match in matches)
//    {
//        string fieldName = match.Groups[1].Value;
//        string dataType = match.Groups[2].Value;
//        string length = match.Groups[3].Value;

//        Console.WriteLine("Tên trường: " + fieldName);
//        Console.WriteLine("Kiểu dữ liệu: " + dataType);
//        Console.WriteLine("Độ dài: " + length);
//        Console.WriteLine("---------------");
//    }
//}
//else
//{
//    Console.WriteLine("Không tìm thấy kết quả phù hợp.");
//}

// Chuỗi đầu vào
string inputString = @"(<拠点コード, varchar(7),>
           ,<管理キー, varchar(16),>
           ,<予定枝番, varchar(4),>
           ,<実績枝番, varchar(4),>
           ,<データ作成日, varchar(8),>
           ,<データ作成時刻, varchar(8),>
           ,<棚卸種別, varchar(2),>
           ,<識別在庫倉庫コード, varchar(5),>
           ,<伝票番号, varchar(10),>
           ,<行No, varchar(2),>
           ,<商品コード, varchar(8),>
           ,<ITFコード, varchar(16),>
           ,<JANコード, varchar(13),>
           ,<注文番号, varchar(8),>
           ,<商品名カナ, varchar(30),>
           ,<商品名漢字, varchar(60),>
           ,<規格名カナ, varchar(10),>
           ,<規格名漢字, varchar(30),>
           ,<ITFコード_予備1, varchar(16),>
           ,<ITFコード_予備2, varchar(16),>
           ,<ITFコード_予備3, varchar(16),>
           ,<JANコード_予備1, varchar(13),>
           ,<JANコード_予備2, varchar(13),>
           ,<JANコード_予備3, varchar(13),>
           ,<CS入数, int,>
           ,<BL入数, int,>
           ,<発注バンドル数, int,>
           ,<組数, int,>
           ,<日付管理区分, varchar(1),>
           ,<独自企画区分, varchar(1),>
           ,<酒区分, varchar(1),>
           ,<配送年月回, varchar(8),>
           ,<返品不可区分, varchar(1),>
           ,<次回企画回, varchar(7),>
           ,<企画区分, varchar(1),>
           ,<予定良品残PS数, int,>
           ,<無償予備数, int,>
           ,<賞味期限日_良品残, varchar(8),>
           ,<予定不良品残PS数, int,>
           ,<賞味期限日_不良品残, varchar(8),>
           ,<出庫限界日, varchar(8),>
           ,<棚卸実績日, varchar(8),>
           ,<棚卸実績時刻, varchar(8),>
           ,<実績良品残PS数, int,>
           ,<実績賞味期限日_良品残, varchar(8),>
           ,<実績不良品残PS数, int,>
           ,<実績賞味期限日_不良品残, varchar(8),>
           ,<ドーリーNo, varchar(12),>
           ,<オリコンNo, varchar(12),>
           ,<移動元ドーリーNo, varchar(12),>
           ,<移動元オリコンNo, varchar(12),>
           ,<エリア, varchar(3),>
           ,<在庫データ種別, varchar(1),>
           ,<複数日付フラグ, varchar(1),>
           ,<繰越可能区分, varchar(1),>
           ,<繰入先配送年月回, varchar(8),>
           ,<処分区分, varchar(2),>
           ,<送信区分_KS, varchar(1),>
           ,<送信日付_KS, varchar(8),>
           ,<送信時刻_KS, varchar(6),>
           ,<作成日付, varchar(8),>
           ,<作成時刻, varchar(6),>
           ,<更新日付, varchar(8),>
           ,<更新時刻, varchar(6),>";

// Khởi tạo các danh sách
List<string> fieldNames = new List<string>();
List<string> dataTypes = new List<string>();
List<string> lengthsOrPrecisions = new List<string>();

// Biểu thức chính quy
string pattern = @"<(.*?),\s*(varchar|int)(?:\((\d+)\))?,>";

// Sử dụng Regex.Matches để tìm kiếm tất cả các kết quả
MatchCollection matches = Regex.Matches(inputString, pattern);

// Kiểm tra xem có kết quả nào không
if (matches.Count > 0)
{
    foreach (Match match in matches)
    {
        // Lưu trữ thông tin vào danh sách tương ứng
        fieldNames.Add(match.Groups[1].Value);
        dataTypes.Add(match.Groups[2].Value);
        lengthsOrPrecisions.Add(match.Groups[3].Value);
    }

    // In ra thông tin từ danh sách
    for (int i = 0; i < fieldNames.Count; i++)
    {
        Console.WriteLine("Name: " + fieldNames[i]);
        Console.WriteLine("Type: " + dataTypes[i]);

        // Kiểm tra nếu có độ dài hoặc precision thì in ra
        if (!string.IsNullOrEmpty(lengthsOrPrecisions[i]))
        {
            Console.WriteLine("Length: " + lengthsOrPrecisions[i]);
        }

        Console.WriteLine("---------------");
    }

    foreach (var fieldName in fieldNames)
    {
        Console.WriteLine(fieldName);
    }
}
else
{
    Console.WriteLine("Không tìm thấy kết quả phù hợp.");
}

static void countLength()
{
    string inputString = "実績枝番";

    // Chuyển chuỗi sang mảng byte sử dụng UTF-8 encoding
    byte[] utf8Bytes = Encoding.UTF8.GetBytes(inputString);

    // Độ dài của mảng byte sẽ là độ dài theo byte của chuỗi
    int byteLength = utf8Bytes.Length;

    Console.WriteLine($"Độ dài của chuỗi '{inputString}' là {byteLength} byte.");
}