/*
Домашнее задание 8.2

Список песен. В методе Main создать список из 
четырех песен. В цикле вывести информацию о каждой песне. Сравнить между 
собой первую и вторую песню в списке.
Песня представляет собой класс с методами для заполнения каждого из 
полей, методом вывода данных о песне на печать, методом, который сравнивает 
между собой два объекта:
class Song{
string name; //название песни
string author; //автор песни
Song prev; //связь с предыдущей песней в списке
//метод для заполнения поля name
//метод для заполнения поля author
//метод для заполнения поля prev
//метод для печати названия песни и ее исполнителя
public string Title(){… возвращ название+исполнитель …}
//метод, который сравнивает между собой два объекта-песни:
public bool override Equals(object d){…} 
}

Домашнее задание 9.1

В класс Song (из домашнего задания 8.2) добавить 
следующие конструкторы:
1) параметры конструктора – название и автор песни, указатель на 
предыдущую песню инициализировать null.
2) параметры конструктора – название, автор песни, предыдущая песня.
В методе Main создать объект mySong. Возникнет ли ошибка при 
инициализации объекта mySong следующим образом: Song mySong = new
Song(); ? 
Исправьте ошибку, создав необходимый конструктор.

*/

using LabWorkWithSongs;

//var songList = new List<Song>();

var pastSong = new Song("Убийца Свин", "ЛСП");

var song = new Song("Не нужна", "ЛСП", pastSong);

pastSong = song;
song = new Song("Канкан", "ЛСП", pastSong);

pastSong = song;
song = new Song("Безумие", "ЛСП", pastSong).WithFeature("Oxxxymiron");

pastSong = song;
song = new Song("Безумие", "ЛСП", pastSong);

foreach (var item in song)
{
    foreach (var element in item)
    {
        Console.WriteLine(element);
    }
    Console.WriteLine();
    Console.WriteLine(item);
}

/*foreach (var item in song)
{
    Console.WriteLine(item);
}*/

/*PrintListSong(songList);
Console.WriteLine();

PrintingTheSongComparisonResult(songList);
Console.WriteLine();
PrintingTheSongComparisonResultName(songList);

Console.WriteLine();
*/

/*for (var i = 0; i < songList.Count; i++)
{
    Console.WriteLine("Сравнивание предыдущей песни в списке с прошлой");
    Console.WriteLine(songList[i]);
    Console.WriteLine(songList[i].ComparisonIsPreviousSong());
}*/

/*void PrintListSong(List<Song> songs)
{
    foreach (var song in songs)
    {
        Console.WriteLine(song);
    }
}*/

/*void PrintingTheSongComparisonResult(List<Song> songs)
{
    Console.WriteLine("Сравнивание предыдущей песни в списке с прошлой");
    for (var i = 1; i < songs.Count; i++)
    {
        Console.WriteLine($"{songs[i - 1]}  and  {songs[i]}");
        if (songs[i - 1].Equals(songs[i]))
        {
            Console.WriteLine("Песни одинаковые");
        }
    }
}*/

/*void PrintingTheSongComparisonResultName(List<Song> songs)
{
    Console.WriteLine("Сравнивание предыдущей песни в списке с прошлой");
    for (var i = 1; i < songs.Count; i++)
    {
        Console.WriteLine($"{songs[i - 1]}  and  {songs[i]}");
        if (songs[i - 1].EqualSongsByName(songs[i]))
        {
            Console.WriteLine("Песни одинаковые");
        }
    }
}*/
