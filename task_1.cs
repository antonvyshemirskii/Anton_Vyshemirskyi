namespace StringLibraryTest;

[TestClass]
public class task_1
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

    public static List<int> GetIntegersFromList(List<object> nonFilteredList)
    {
        List<int> filteredList = new List<int>();

        filteredList = (from elem in nonFilteredList
                       where elem is int
                       select (int)elem).ToList();
        return filteredList;
    }


}   


