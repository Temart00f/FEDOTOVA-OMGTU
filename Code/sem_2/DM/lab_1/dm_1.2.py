matrix = []

n = int(input('Введите количество вершин: '))
data = []
for i in range(n):
    string = input('Введите строку матрицы: ')
    for sym in string:
        data.append(int(sym))
    matrix.append(data)
    data = []

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
