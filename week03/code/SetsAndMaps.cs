using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        //create an empty set and list
        HashSet<string> checkd = new();
        List<string> results = new List<string>();

        //check each word, foreach runs at O(n)
        foreach (string word in words)
        {
            //check to see if first and second letter are same
            // if they are not the same, execute block
            if (!(word[0] == word[1]))
            {
                //reverse incoming word
                string reversed = $"{word[1]}{word[0]}";

                // using .Contains on an array is O(n), just like a loop
                // if (words.Contains(reversed))
                // {
                //     //add the word to the set if it's not there    
                //     if (checkd.Add(word))
                //     {
                //         //if I'm adding the word to the set, add the reversed also
                //         checkd.Add(reversed);
                //         //add both words to the HashSet if neither were there  --should I put this in a different if statement?
                //         results.Add($"{word} & {reversed}");
                //         Console.WriteLine($"True: {word}, {reversed}");
                //     }
                // }
                if (checkd.Contains(reversed))
                {
                    //add both words to the HashSet if neither were there  --should I put this in a different if statement?
                    results.Add($"{word} & {reversed}");
                }
                checkd.Add(reversed);
                checkd.Add(word);  //do I need to add this?
            }
        }
        
        // Test loop is another O(n)
        // Console.WriteLine("*********************************");
        // foreach (string item in results)
        // {
        //     Console.Write($"{item}, ");
        // }

        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))  //read file into line, 
        {
            //for each line
            var fields = line.Split(",");
                        
            var degree = fields[3];   //column 4
            
            //check to see if the dictionary contains the key that matches the degree
            if (!degrees.ContainsKey(degree))
            {
                degrees[degree] = 1;  //if it's not already there, add degree as key and 1 as value
            }
            else
            {
                degrees[degree] += 1;  // if it's there, increment value
            }       

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        //create a dictionary to hold value of each letter
        var chars1 = new Dictionary<char, int>();
        var chars2 = new Dictionary<char, int>();

        // get rid of spaces and uppercase       
        var newWord1 = word1.ToLower().Replace(" ", "");
        var newWord2 = word2.ToLower().Replace(" ", "");

        // if they are not the same size after normalizing, return false
        if (newWord1.Length != newWord2.Length)
        {
            return false;
        }

        foreach (char character in newWord1)
        {
            //if not already there, add character to dictionary as key
            if (!chars1.ContainsKey(character))
            {
                //set value to 1
                chars1[character] = 1;
            }
            else
            {
                //if key already there
                //add 1 to value
                chars1[character] += 1;                
            }
        }

        foreach (char character in newWord2)
        {
            //check to see if word2 character at same index is in dictionary
            if (!chars1.ContainsKey(character))
            {
                //if it's there, add character and -1 to dictionary
                chars1[character] = -1;
            }
            else
            {
                //if it's there, add -1 to value
                chars1[character] -= 1;
                
            }
        }

        foreach (var item in chars1)
        {
            if (item.Value != 0)
            {
                return false;
            }
        }

     
        return true;
    }    
            //can't use a hashset because it will eliminate duplicate letters
        // HashSet<string> words = new HashSet<string>();
        // mostly works, but not fast enough, and doesn't work for last two tests
        // //convert incoming words to character arrays
        // char[] chars1 = word1.ToCharArray();  //O(n)
        // char[] chars2 = word2.ToCharArray();  //O(n)
        // Array.Sort(chars1);//O(n)
        // Array.Sort(chars2);//O(n)
        // string sortedWord1 = new string(chars1);
        // string sortedWord2 = new string(chars2);
        // string newSortedWord1 = sortedWord1.Trim();//O(n)
        // string newSortedWord2 = sortedWord1.Trim();//O(n)
        // sortedWord2.Trim();
        // Console.WriteLine("********************************");
        // Console.WriteLine("sortedWord1: " + newSortedWord1);
        // Console.WriteLine("SortedWord2: " + newSortedWord2);

        // //ToLower is O(n)
        // if (newSortedWord1.ToLower() == newSortedWord2.ToLower())
        // {
        //     return true;
        // }

        // return false;
    

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        //  2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        List<string> earthquakes = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties.Place;
            var mag = feature.Properties.Mag;
            earthquakes.Add($"Place: {place} - Mag {mag}");
            Console.WriteLine("Earthquakes_________***************");
            Console.WriteLine($"Place: {place} - Mag {mag}");
        }

        // 3. Return an array of these string descriptions.

            return earthquakes.ToArray();
    }
}