using System;
using System.Collection.Generic;


public class TestClass : IJsonFormat
{
	public int intValue;
	public List<string> lstStr;

	public TestClass(){
		lstStr = new List<string();
	}
	
	public Dictionary<string, object> ToJsonDictionary(){
		Dictionary<string, object> dic = new Dictionary<string, object>();
		dic["intValue"] = intValue;
		dic["lstStr"] = lstStr;
		return dic;
	}

	public void FromJsonDictionary(Dictionary<string, object> dic){
		intValue = (int)dic["intValue"];
		List<object> lst = dic["lstStr"] as List<string>;
		for(int i=0; i<lst.Count; ++i){
			lstStr.Add(lst[i] as string);
		}
	}

	public static void Main(string[] args){
		List<TestClass> lstTest = new List<TestClass>();
		for(int i=0; i<10; ++i){
			TestClass test = new TestClass();
			test.intValue = i;
			test.lstStr.Add(i.ToStriing());
		}
		string jsonStr = MiniJSON.Json.Serialize(lstTest);

		List<object> lstDeserialized = MiniJSON.Json.Deserialize(jsonStr) as List<object>;
		for(int i=0; i<lstDeserialized.Count; ++i){
			Dictionary<string, object> dicTestClass = lstDeserialized[i] as Dictionary<string, object>;
			TestClass testClass = new TestClass();
			testClass.FromJsonDictionary(dicTestClass);
		}
	}
}



