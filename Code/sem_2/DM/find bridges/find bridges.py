def find_components(n, visited, matrix):
    visited[n] = True
    for i in range(len(matrix)):
        if matrix[n][i] != 0 and not visited[i]:
            find_components(i, visited, matrix)

def kruskal(matrix):
    edges = []
    for i in range(len(matrix)):
        for j in range(i + 1, len(matrix[i])):
            if matrix[i][j] != 0:
                edges.append((matrix[i][j], i, j))
    edges.sort()

    parent = list(range(len(matrix)))
    min_edges = []
    for edge in edges:
        weight, u, v = edge
        root_u = find_parent(parent, u)
        root_v = find_parent(parent, v)
        if root_u != root_v:
            min_edges.append((u, v))
            union(parent, u, v)

    return min_edges

def find_parent(parent, vertex):
    if parent[vertex] != vertex:
        parent[vertex] = find_parent(parent, parent[vertex])
    return parent[vertex]

def union(parent, vertex1, vertex2):
    root1 = find_parent(parent, vertex1)
    root2 = find_parent(parent, vertex2)
    if root1 != root2:
        parent[root1] = root2

def find_bridges(matrix):
    mst_edges = kruskal(matrix)
    bridges = []
    for edge in mst_edges:
        u, v = edge
        copy_matrix = [row[:] for row in matrix]
        copy_matrix[u][v] = copy_matrix[v][u] = 0

        visited = [False] * len(copy_matrix)
        components = 0
        for i in range(len(copy_matrix)):
            if not visited[i]:
                find_components(i, visited, copy_matrix)
                components += 1

        if components > 1:
            bridges.append(edge)

    return bridges

#ответ (1,2)
matrix = [
    [0, 1, 0, 0, 3, 2],
    [1, 0, 2, 3, 0, 0],
    [0, 2, 0, 4, 0, 0],
    [0, 3, 4, 0, 0, 0],
    [3, 0, 0, 0, 0, 8],
    [2, 0, 0, 0, 8, 0]
]

bridges = find_bridges(matrix)
if bridges:
    print("Мостами являются ребра:")
    for el in bridges:
        print(f"({el[0] + 1}, {el[1] + 1})")
else:
    print("Мостов нет")