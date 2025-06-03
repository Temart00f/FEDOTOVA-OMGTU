from collections import deque
def max_flow(graph, source, sink):
    residual = [row[:] for row in graph]
    parent = [-1] * len(graph)
    max_flow = 0

    def bfs():
        visited = [False] * len(graph)
        queue = deque([source])
        visited[source] = True
        while queue:
            u = queue.popleft()
            for v, capacity in enumerate(residual[u]):
                if not visited[v] and capacity > 0:
                    visited[v] = True
                    parent[v] = u
                    if v == sink:
                        return True
                    queue.append(v)
        return False

    while bfs():
        path_flow = float('inf')
        s = sink
        while s != source:
            path_flow = min(path_flow, residual[parent[s]][s])
            s = parent[s]

        v = sink
        while v != source:
            u = parent[v]
            residual[u][v] -= path_flow
            residual[v][u] += path_flow
            v = u
        max_flow += path_flow
    return max_flow

graph = [
    [0, 76, 0, 41, 0, 47],
    [0, 0, 44, 56, 0, 0],
    [0, 0, 0, 50, 0, 0],
    [0, 0, 0, 0, 0, 0],
    [0, 35, 13, 29, 0, 0],
    [0, 0, 15, 0, 25, 0]
]
source = 0
sink = 3

print("Максимальный поток:", max_flow(graph, source, sink))