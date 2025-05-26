matrix = []

start = [1, 1]
finish = [5, 5]

matrix[start[0]][start[1]] = 0

for k in range(len(matrix)**2):
    if matrix[finish[0]][finish[1]] != ' ':
        break
    for i in range(len(matrix)):
        for j in range(len(matrix[0])):
            if matrix[i][j] != 'x' and matrix[i][j] != " ":
                if i > 0 and matrix[i - 1][j] == ' ':
                    matrix[i - 1][j] = matrix[i][j] + 1
                if i < len(matrix) - 1 and matrix[i + 1][j] == ' ':
                    matrix[i + 1][j] = matrix[i][j] + 1
                if j > 0 and matrix[i][j - 1] == ' ':
                    matrix[i][j - 1] = matrix[i][j] + 1
                if j < len(matrix[0]) - 1 and matrix[i][j + 1] == ' ':
                    matrix[i][j + 1] = matrix[i][j] + 1

if matrix[finish[0]][finish[1]] != ' ':
    print(f'Возможно дойти до финиша за {matrix[finish[0]][finish[1]]} шагов')
else:
    print("Невозможно дойти до финиша")

for row in matrix:
    print(row)