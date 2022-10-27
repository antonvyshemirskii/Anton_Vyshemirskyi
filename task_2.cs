namespace StringLibraryTest;

[TestClass]
public class task_2
{
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

}

