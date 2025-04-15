n = int(input('Введите количество вершин: '))
matrix = []

for i in range(n):
    data = []
    string = input('Введите строку матрицы смежности(через пробел): ')
    matrix.append(string.split(' '))
for i in range(n):
    for j in range(n):
        matrix[i][j] = int(matrix[i][j])

start_vertex = int(input('Введите начальную вершину: ')) - 1
end_vertex = int(input('Введите конечную вершину: ')) - 1
current_vertex = start_vertex
visited = [0] * n
distance = [float('inf')] * n
path = [-1] * n

visited[start_vertex] = 1
distance[start_vertex] = 0

for i in range(n):
    related = []
    for k in range(n):
        if matrix[current_vertex][k] > 0:
            related.append(k)
    for j in related:
        if visited[j] == 0:
            if distance[j] == float('inf'):
                distance[j] = distance[current_vertex] + matrix[current_vertex][j]
                path[j] = current_vertex
            elif distance[j] != float('inf') and distance[current_vertex] + matrix[current_vertex][j] < distance[j]:
                distance[j] = distance[current_vertex] + matrix[current_vertex][j]
                path[j] = current_vertex
    min = [-1, float('inf')]
    visited[current_vertex] = 1
    for v in range(len(distance)):
        if distance[v] < min[1] and visited[v] != 1:
            min = [v, distance[v]]
    current_vertex = min[0]
cur = end_vertex
result = []
while cur != -1:
    result.append( ur + 1)
    cur = path[cur]
result.reverse()

if distance[end_vertex] == float('inf'):
    print(f'Нет пути от {start_vertex} к {end_vertex}')
else:
    print(f'\nРасстояние: {distance[end_vertex]}\nПуть: {f"-".join(map(str ,result))}')