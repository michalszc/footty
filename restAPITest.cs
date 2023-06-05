
using System.Net;
using System.Text.Json;

updateMatch();

// Getting match
void getMatch() {
    Console.WriteLine("Enter match id");
    var index = Console.ReadLine();


    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5221/api/matches/"+index+"/admin/6Y4ne9npAJFyssinCYVY2GfC");

    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "GET";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

// Getting team
void getTeam() {
    Console.WriteLine("Enter match id");
    var index = Console.ReadLine();


    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5221/api/teams/"+index+"/admin/6Y4ne9npAJFyssinCYVY2GfC");

    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "GET";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

// Adding team
void createTeam() {
    Console.WriteLine("Enter team name");
    var name = Console.ReadLine();

    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5221/api/teams/"+name+"/admin/6Y4ne9npAJFyssinCYVY2GfC");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

// Getting player
void getPlayer() {
    Console.WriteLine("Enter club id");
    var index = Console.ReadLine();
    Console.WriteLine("Enter shirt number");
    var shirt = Console.ReadLine();


    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5221/api/players/"+index+"/"+shirt+"/admin/6Y4ne9npAJFyssinCYVY2GfC");

    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "GET";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

// Getting stadium
void getStadium() {
    Console.WriteLine("Enter city");
    var city = Console.ReadLine();

    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:5221/api/stadions/"+city+"/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "GET";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

// Updating match
void updateMatch() {
    Console.WriteLine("Enter match id");
    var index = Console.ReadLine();

    var date = "4/10/2020";

    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/matches/"+index+"/2/2/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "PUT";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void updateTeam() {
    Console.WriteLine("Enter team id");
    var index = Console.ReadLine();

    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/teams/"+index+"/EditedName/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "PUT";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void updateStadium() {
    Console.WriteLine("Enter stadium id");
    var index = Console.ReadLine();

    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/stadions/"+index+"/2/Barcelona/NowyName/90000/3.85/4.85/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "PUT";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void updatePlayer() {
    Console.WriteLine("Enter team id");
    var index = Console.ReadLine();

    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/players/"+index+"/2/Striker/97/90/1/0/1/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "PUT";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void createMatch() {
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/matches/20_06_2023/1/2/Home/5/0/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void createPlayer() {
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/players/1/Goalkeeper/97/0/0/0/0/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void createStadium() {
    Console.WriteLine("Give stadium name");
    var name = Console.ReadLine();
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/stadions/1/Madrid/"+name+"/80000/2.85/3.85/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void deleteMatch() {
    Console.WriteLine("Enter match id:");
    var id = Console.ReadLine();
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/matches/"+id+"/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "DELETE";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void deleteTeam() {
    Console.WriteLine("Enter match id:");
    var id = Console.ReadLine();
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/teams/"+id+"/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "DELETE";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void deletePlayer() {
    Console.WriteLine("Enter player id:");
    var id = Console.ReadLine();
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/players/"+id+"/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "DELETE";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

void deleteStadium() {
    Console.WriteLine("Enter stadium id:");
    var id = Console.ReadLine();
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(
        "http://localhost:5221/api/stadions/"+id+"/admin/6Y4ne9npAJFyssinCYVY2GfC");


    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "DELETE";

    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
        Console.WriteLine(result);
    }
}

