namespace StringLibraryTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void GetIntegersFromListTest1(){
        CollectionAssert.AreEquivalent(new List<int>{1, 2}, GetIntegersFromList(new List<object> {1, 2, "a", "b"}));
    }

    [TestMethod]
    public void GetIntegersFromListTest2(){
        CollectionAssert.AreEquivalent(new List<int>{1, 2, 0, 15}, GetIntegersFromList(new List<object> {1, 2, "a", "b", 0, 15}));
    }
    [TestMethod]
    public void GetIntegersFromListTest3(){
        CollectionAssert.AreEquivalent(new List<int>{1, 2, 231}, GetIntegersFromList(new List<object> {1, 2, "a", "b", "aasf", "1", "123", 231}));
    }

    [TestMethod]
    public void FirstNonRepeatLetterTest1(){
        Assert.AreEqual("t", FirstNonRepeatLetter("stress"));
    }
    
    [TestMethod]
    public void FirstNonRepeatLetterTest2(){
        Assert.AreEqual("T", FirstNonRepeatLetter("sTress"));
    }

    [TestMethod]
    public void FirstNonRepeatLetterTest3(){
        Assert.AreEqual("", FirstNonRepeatLetter("srreess"));
    }
    
    [TestMethod]
    public void DigitalRootTest1(){
        Assert.AreEqual(7, DigitalRoot(16));
    }
    [TestMethod]
    public void DigitalRootTest2(){
        Assert.AreEqual(6, DigitalRoot(132189));
    }
    [TestMethod]
    public void DigitalRootTest3(){
        Assert.AreEqual(9, DigitalRoot(9));
    }

    [TestMethod]
    public void NumberPairsTest1(){
        Assert.AreEqual(4, NumberPairs(new[]{1, 3, 6, 2, 2, 0, 4, 5}));
    }
    [TestMethod]
    public void NumberPairsTest2(){
        Assert.AreEqual(2, NumberPairs(new[]{3, 3, 2, 1, 0, 1, 0}));
    }
    [TestMethod]
    public void NumberPairsTest3(){
        Assert.AreEqual(0, NumberPairs(new[]{100, 3, 100, 1, 0, 1, 0}));
    }

    [TestMethod]
    public void FormatTextTest1(){
        Assert.AreEqual("(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)", FormatText("Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill"));
    }
    [TestMethod]
    public void FormatTextTest2(){
        Assert.AreEqual("(CORWILL, ALFRED)(CORWILL, ALFRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BARNEY)(TORNBULL, BJON)", FormatText("Alfred:Corwill;Wilfred:Corwill;Barney:TornBull;Barney:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill"));
    }
    [TestMethod]
    public void FormatTextTest3(){
        Assert.AreEqual("(CORWILL, ALFRED)", FormatText("Alfred:Corwill"));
    }

    [TestMethod]
    public void NextBiggerTest1(){
        Assert.AreEqual(21, NextBigger(12));
    }
    [TestMethod]
    public void NextBiggerTest2(){
        Assert.AreEqual(2073121, NextBigger(2071321));
    }
    [TestMethod]
    public void NextBiggerTest3(){
        Assert.AreEqual(-1, NextBigger(531));
    }
        
    [TestMethod]
    public void ToIPv4Test1(){
        Assert.AreEqual("128.32.10.1", ToIPv4(2149583361));
    }    
    [TestMethod]
    public void ToIPv4Test2(){
        Assert.AreEqual("0.131.51.15", ToIPv4(2149583));
    }
    [TestMethod]
    public void ToIPv4Test3(){
        Assert.AreEqual("0.0.0.32", ToIPv4(32));
    }
    [TestMethod]
    public void ToIPv4Test4(){
        Assert.AreEqual("0.0.0.0", ToIPv4(0));
    }
    public static List<int> GetIntegersFromList(List<object> nonFilteredList)
    {
        List<int> filteredList = new List<int>();

        filteredList = (from elem in nonFilteredList
                       where elem is int
                       select (int)elem).ToList();
        return filteredList;
    }
    public static string FirstNonRepeatLetter(string word)
    {
        char firstNonRepeatLetter;

        foreach(char elem in word){
            firstNonRepeatLetter = elem;

            if(word.ToLower().Split(Char.ToLower(elem)).Length - 1 == 1){
                return firstNonRepeatLetter.ToString();
            }
        }
        return "";
    }

    public static int DigitalRoot(int n){
        if(n < 10){
            return n;
        }
        string nString = n.ToString();
        n = 0;
        foreach(var num in nString){
            n += int.Parse(num.ToString());
        }
        return DigitalRoot(n);  
    }

    public static int NumberPairs(int[] arr, int target = 5){
        int numberPairs = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++){
                if(arr[i] + arr[j] == target){
                    numberPairs++;
                }
            }
        }
        return numberPairs;
    }

    public static string FormatText(string listFriends){
                
        string [] subStrings = listFriends.Split(";");
        subStrings = (from str in subStrings 
                      orderby str.Substring(str.IndexOf(":")+1).ToUpper(), str.Substring(0, str.IndexOf(":")).ToUpper()
                      select "(" + str.Substring(str.IndexOf(":")+1).ToUpper() + ", " + str.Substring(0, str.IndexOf(":")).ToUpper() + ")").ToArray();
        return string.Join("",subStrings);
    }

    public static int NextBigger(int num){

        int[] numArr = num.ToString().Select(o=> Convert.ToInt32(o) - 48 ).ToArray();
        for (int i = numArr.Length - 1; i != 0; i--)
        {
            if(numArr[i-1] < numArr[i]){
                (numArr[i-1], numArr[i]) = (numArr[i], numArr[i-1]);
                return Int32.Parse(string.Join("", numArr));
            }
        }
        return -1;
    }

    public static string ToIPv4(UInt32 num){
        string numBinary = Convert.ToString(num, 2);
        string IPv = "";
        if(num == 0)
        {
            return "0.0.0.0";
        }
        else if(numBinary.Length > 1 && numBinary.Length < 8)
        { 
            IPv = "0.0.0.";
        }
        else if(numBinary.Length > 8 && numBinary.Length < 16){
            IPv = "0.0.";
        }
        else if(numBinary.Length > 16 && numBinary.Length < 24){
            IPv = "0.";
        }
        
        for (int i = 0; i < numBinary.Length; i+=8)
        {
            if(i+8 >= numBinary.Length){
                IPv += Convert.ToString(Convert.ToInt32(numBinary.Substring(i, numBinary.Length-i), 2), 10);
            }
            else{  
                IPv += Convert.ToString(Convert.ToInt32(numBinary.Substring(i, 8), 2), 10);
                IPv += ".";
            }
        }
        return IPv;
        

    }

}   


