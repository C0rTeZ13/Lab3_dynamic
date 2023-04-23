using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void BellmanFord(List<(int u, int v, int w)> edges, int start, int n)
    {
        int[] dist = new int[n];
        int[] pred = new int[n];

        for (int i = 0; i < n; i++)
        {
            dist[i] = int.MaxValue;
            pred[i] = -1;
        }
        dist[start] = 0;

        // Повторяем n-1 раз, чтобы убедиться, что все пути найдены
        for (int i = 1; i <= n - 1; i++)
        {
            foreach (var edge in edges)
            {
                int u = edge.u;
                int v = edge.v;
                int w = edge.w;
                if (dist[u] != int.MaxValue && dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    pred[v] = u;
                }
            }
        }

        // Проверяем, есть ли отрицательный цикл
        foreach (var edge in edges)
        {
            int u = edge.u;
            int v = edge.v;
            int w = edge.w;
            if (dist[u] != int.MaxValue && dist[u] + w < dist[v])
            {
                Console.WriteLine("Отрицательный цикл обнаружен");
                return;
            }
        }

        // Выводим результат
        for (int i = 0; i < n; i++)
        {
            if (start != i) {
                Console.Write("Расстояние от {0} до {1}: ", start + 1, i + 1);
                if (dist[i] == int.MaxValue)
                    Console.WriteLine("нет пути");
                else
                    Console.WriteLine(dist[i]);
            }
        }
    }
    public static void Main()
    {
        List<(int u, int v, int w)> edges = new List<(int u, int v, int w)>();
        edges.Add((0, 1, 8));
        edges.Add((0, 4, 11));
        edges.Add((1, 2, 15));
        edges.Add((1, 5, 9));
        edges.Add((2, 3, 2));
        edges.Add((2, 6, 1));
        edges.Add((3, 6, 6));
        edges.Add((4, 1, 3));
        edges.Add((4, 2, 11));
        edges.Add((4, 5, 10));
        edges.Add((5, 3, 1));
        edges.Add((5, 6, 3));
        int start = 0;
        int n = 7;
        BellmanFord(edges, start, n);
        Console.ReadLine();
    }
}