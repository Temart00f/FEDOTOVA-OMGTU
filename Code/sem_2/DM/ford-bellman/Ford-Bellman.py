n = int(input('Введите количество вершин: '))
matrix = []

for i in range(n):
    data = []
    string = input('Введите строку матрицы смежности(через пробел): ')
    matrix.append(string.split(' '))
for i in range(n):
    for j in range(n):
        matrix[i][j] = int(matrix[i][j])

start_vertex = int(input("Введите номер начальной вершины: ")) - 1
distance = [float('inf')] * n
distance[start_vertex] = 0

for i in range(n - 1):
    for u in range(n):
        for v in range(n):
            if matrix[u][v] != 0:
                if distance[u] + matrix[u][v] < distance[v]:
                    distance[v] = distance[u] + matrix[u][v]
for u in range(n):
    for v in range(n):
        if matrix[u][v] != 0:
            if distance[u] + matrix[u][v] < distance[v]:
                print('В графе есть цикл с отрицательной суммарной массой')
                exit()

print('Кратчайшие расстояния от вершины', start_vertex + 1)
for j in range(n):
    if distance[j] == float('inf'):
        print(f'Вершина {j + 1} недостижима')
    else:
        print(f'Вершина {j + 1}: {distance[j]}')