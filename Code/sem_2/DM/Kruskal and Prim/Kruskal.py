matrix = []
edges = []

for i in range(len(graph)):
    for j in range(i + 1, len(graph[i])):
        if graph[i][j] != 0:
            edges.append((graph[i][j], i, j))
edges.sort()

parent = [i for i in range(len(graph))]
def find(vertex):
    if parent[vertex] != vertex:
        parent[vertex] = find(parent[vertex])
    return parent[vertex]

min_weight = 0
min_edges = []
for edge in edges:
    weight, u, v = edge
    root_u = find(u)
    root_v = find(v)
    if root_u != root_v:
        min_edges.append(edge)
        min_weight += weight
        parent[root_u] = root_v

print(f"Сумма весов остовного дерева: {min_weight}")