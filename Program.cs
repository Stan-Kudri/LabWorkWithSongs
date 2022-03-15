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

var songList = new List<Song>();
songList.Add(new Song("Не нужна", "ЛСП"));
songList.Add(new Song("Убийца Свин", "ЛСП"));
songList.Add(new Song("Спининг", "ЛСП"));
songList.Add(new Song("Не нужна", "ЛСП"));

foreach (var song in songList)
{
    Console.WriteLine(song);
}

PrintingTheSongComparisonResult(songList);

void PrintingTheSongComparisonResult(List<Song> songs)
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
}
