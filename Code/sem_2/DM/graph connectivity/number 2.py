matrix = []

n = int(input('Введите количество вершин: '))

for i in range(n):
    data = []
    string = input('Введите строку матрицы смежности(через пробел): ')
    matrix.append(string.split(' '))
for i in range(n):
    for j in range(n):
        matrix[i][j] = int(matrix[i][j])

vertex_values = {0:1}
max_value = 1

for i in range(1, n):
    vertex_values[i] = 0

for i in range(n):
    for j in range(i):
        if matrix[j][i] == 1:
            if vertex_values[i] == 0:
                vertex_values[i] = vertex_values[j]
            else:
                vertex_values[i] = min(vertex_values[i], vertex_values[j])
                vertex_values[j] = vertex_values[i]
    if vertex_values[i] == 0:
        max_value += 1
        vertex_values[i] = max_value

print(f'Количество компонент связности: {max(vertex_values.values())}')
