import copy
n = 6
matrix = [
    [float('inf'), 31, 15, 9, 18, 15],
    [9, float('inf'), 26, 31, 71, 45],
    [25, 23, float('inf'), 23, 27, 26],
    [5, 50, 19, float('inf'), 11, 19],
    [24, 24, 33, 5, float('inf'), 19],
    [64, 66, 6, 63, 36, float('inf')]
]

current_matrix = copy.deepcopy(matrix)
lower_bound = 0

for i in range(n):
    row = current_matrix[i]
    min_val = float('inf')
    for val in row:
        if val < min_val and val != float('inf'):
            min_val = val
    if min_val != 0 and min_val != float('inf'):
        lower_bound += min_val
        for j in range(n):
            if current_matrix[i][j] != float('inf'):
                current_matrix[i][j] -= min_val

for j in range(n):
    col_vals = [current_matrix[i][j] for i in range(n)]
    min_val = float('inf')
    for val in col_vals:
        if val < min_val and val != float('inf'):
            min_val = val
    if min_val != 0 and min_val != float('inf'):
        lower_bound += min_val
        for i in range(n):
            if current_matrix[i][j] != float('inf'):
                current_matrix[i][j] -= min_val

path = []

while len(path) < n:
    max_edge_score = -1
    selected_edge = (-1, -1)
    for i in range(n):
        for j in range(n):
            if current_matrix[i][j] == 0:
                row_vals = [current_matrix[i][k] for k in range(n) if k != j]
                min_row = float('inf')
                for val in row_vals:
                    if val < min_row and val != float('inf'):
                        min_row = val
                if min_row == float('inf'):
                    min_row = 0

                col_vals = [current_matrix[k][j] for k in range(n) if k != i]
                min_col = float('inf')
                for val in col_vals:
                    if val < min_col and val != float('inf'):
                        min_col = val
                if min_col == float('inf'):
                    min_col = 0

                edge_score = min_row + min_col

                if edge_score > max_edge_score:
                    max_edge_score = edge_score
                    selected_edge = (i, j)

    i, j = selected_edge
    path.append((i, j))
    lower_bound += max_edge_score

    current_matrix[j][i] = float('inf')

    for k in range(n):
        current_matrix[i][k] = float('inf')
        current_matrix[k][j] = float('inf')

    for i_row in range(n):
        row = current_matrix[i_row]
        min_val = float('inf')
        for val in row:
            if val < min_val and val != float('inf'):
                min_val = val
        if min_val != 0 and min_val != float('inf'):
            lower_bound += min_val
            for j_col in range(n):
                if current_matrix[i_row][j_col] != float('inf'):
                    current_matrix[i_row][j_col] -= min_val

    for j_col in range(n):
        col_vals = [current_matrix[i_row][j_col] for i_row in range(n)]
        min_val = float('inf')
        for val in col_vals:
            if val < min_val and val != float('inf'):
                min_val = val
        if min_val != 0 and min_val != float('inf'):
            lower_bound += min_val
            for i_row in range(n):
                if current_matrix[i_row][j_col] != float('inf'):
                    current_matrix[i_row][j_col] -= min_val

route = []
start = 0
route.append(start)

while len(route) < n:
    for edge in path:
        if edge[0] == start:
            route.append(edge[1])
            start = edge[1]
            break

route.append(route[0])

total_cost = 0
for i in range(len(route) - 1):
    total_cost += matrix[route[i]][route[i + 1]]

print("Маршрут:")
for i in range(len(route) - 1):
    print(f"{route[i] + 1} -> {route[i + 1] + 1}")
print("Нижняя оценка:", total_cost)