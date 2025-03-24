n = int(input('Введите количество вершин графа: '))
current = [0]
visited = set()
visited.add(0)
matrix = []

for i in range(n):
    data = []
    string = input('Введите строку матрицы смежности: ')
    for j in string:
        data.append(int(j))
    matrix.append(data)

print('Матрица смежности: ')
for i in range(n):
    print(matrix[i])

def depth_first(count, num, cur, visited):
    for i in range(n):
        if matrix[num][i] == 1 and i not in cur:
            cur.append(i)
            return depth_first(count, i, cur, visited.union({i}))
        elif i == n - 1:
            back_index = cur.index(num) - 1
            if back_index >= 0:
                return depth_first(count, cur[back_index], cur, visited)
            elif back_index < 0:
                for j in range(n):
                    if j not in visited:
                        print(f'Компонента: {cur}')
                        cur.clear()
                        cur.append(j)
                        return depth_first(count+1, j, cur, visited.union({j}))
                    elif list(visited) == list(range(n)):
                        print(f'Компонента: {cur}')
                        print('Всего компонент: ')
                        return count

print(depth_first(1, 0, current, visited))
