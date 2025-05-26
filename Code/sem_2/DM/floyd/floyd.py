martix = []

n = len(martix)
for k in range(n):
    for i in range(n):
        for j in range(n):
            if martix[i][k] != 0 and martix[k][j] != 0:
                if martix[i][j] == 0 or martix[i][j] > martix[i][k] + martix[k][j]:
                    martix[i][j] = martix[i][k] + martix[k][j]

print("  ", end="")
for v in range(1, n + 1):
    print(v, end=" ")
print()
for i in range(n):
    print(i + 1, end=" ")
    for j in range(n):
        if martix[i][j] == 0:
            print("-", end=" ")
        else:
            print(martix[i][j], end=" ")
    print()