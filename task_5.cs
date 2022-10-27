namespace StringLibraryTest;

[TestClass]
public class task_5
{
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
    public static string FormatText(string listFriends){
                
        string [] subStrings = listFriends.Split(";");
        subStrings = (from str in subStrings 
                      orderby str.Substring(str.IndexOf(":")+1).ToUpper(), str.Substring(0, str.IndexOf(":")).ToUpper()
                      select "(" + str.Substring(str.IndexOf(":")+1).ToUpper() + ", " + str.Substring(0, str.IndexOf(":")).ToUpper() + ")").ToArray();
        return string.Join("",subStrings);
    }
}