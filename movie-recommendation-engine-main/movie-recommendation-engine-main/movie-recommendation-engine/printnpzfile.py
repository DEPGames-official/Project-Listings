import numpy as np
import scipy.sparse as sp

npz_file = np.load("combined_data_matrix.npz")
csr_matrix = sp.csr_matrix((npz_file['data'], npz_file['indices'], npz_file['indptr']), shape=npz_file['shape'])
is_csr = sp.isspmatrix_csr(csr_matrix)
print(is_csr)
print(csr_matrix.shape)

row_indices, col_indices, values = sp.find(csr_matrix)

for i in range(len(values)):
    print(f"({row_indices[i]}, {col_indices[i]}) = {values[i]}")


#for file in data.files:
    #print(file)
    #print(data[file])
