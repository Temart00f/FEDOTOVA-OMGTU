def get_length_max_shortest_path(n, matrix):

    dist = [[float('inf')] * n for i in range(n)]
    max_dist = 0

    for i in range(n):
        for j in range(n):
            if i == j:
                dist[i][j] = 0
            elif matrix[i][j] != 0:
                dist[i][j] = matrix[i][j]

    for i in range(n):
        for j in range(n):
            for k in range(n):
                if dist[j][k] > dist[j][i] + dist[i][k]:
                    dist[j][k] = dist[j][i] + dist[i][k]

    for i in range(n):
        for j in range(n):
            if dist[i][j] != float('inf') and dist[i][j] > max_dist:
                max_dist = dist[i][j]

    return max_dist

n = int(input())
matrix = []

for i in range(n):
    row = list(map(int, input().split()))
    matrix.append(row)

result = get_length_max_shortest_path(n, matrix)
print(result)