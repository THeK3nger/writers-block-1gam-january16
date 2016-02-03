using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Retreive and format database text.
/// </summary>
public class TextDB : MonoBehaviour {

	public List<TextAsset> TextDatabase;

	public string[] ServeText(int index) {
		return SplitAllByWrods(SplitLines(TextDatabase[index].text));
	}

    private static string[] SplitLines(string text) {
		var result = text.Split('\n');

		// Re-add end lines. We need them.
		for (var i=0;i<result.Length;i++) {
			result[i] = result[i] + "\n";
		}
		return result;
	}

    private static string[] SplitAllByWrods(string[] lines) {
		var result = new List<string>();
		foreach (var words in lines.Select(line => line.Split(' ')))
		{
		    result.AddRange(words);
		}
		return result.ToArray();
	}

}
