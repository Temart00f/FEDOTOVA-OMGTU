def prim(graph, start_vertex):
    num_vertices = len(graph)
    visited = [False] * num_vertices
    visited[start_vertex - 1] = True
    total_weight = 0
    while sum(visited) < num_vertices:
        min_weight = float('inf')
        min_edge = None
        for i in range(num_vertices):
            if visited[i]:
                for j in range(num_vertices):
                    if not visited[j] and graph[i][j] > 0 and graph[i][j] < min_weight:
                        min_weight = graph[i][j]
                        min_edge = (i, j)
        if min_edge is None:
            break
        total_weight += min_weight
        visited[min_edge[1]] = True
    return total_weight
