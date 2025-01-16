import csv
import numpy as np
from scipy.sparse import csr_matrix, save_npz
import scipy.sparse as sp

'''
# Step 1: Load movie data from CSV file
print("Loading movie data from csv file...")
movies = {}
with open('archive/movie_titles.csv', 'r', encoding = "windows-1252") as f:
    reader = csv.reader(f)
    next(reader) # skip header
    for row in reader:
        movie_num = int(row[0])
        movie_year = int(row[1]) if row[1] != "NULL" else 0
        movie_name = row[2]
        movies[movie_num] = {'name': movie_name, 'year': movie_year}
'''
'''
# Step 2: Load rating data from text file in batches
print("Loading rating data from text file in batches...")
batch_size = 1000000 # number of lines to read at a time
ratings = {}
with open(f'archive/combined_data_4.txt', 'r') as f:
    offset = 13368
    while True:
        batch = []
        for line in f:
            line = line.strip()
            if line.endswith(':'):
                movie_num = int(line[:-1]) - offset
                ratings[movie_num] = []
            else:
                values = line.strip().split(',')
                if len(values) == 3:
                    user_id, rating, rating_date = values
                    user_id = int(user_id)
                    rating = float(rating)
                    batch.append((movie_num, user_id, rating))
            if len(batch) == batch_size:
                break
        if not batch:
            break
        for movie_num, user_id, rating in batch:
            ratings[movie_num].append((user_id, rating))

# Step 3: Create empty user-item matrix
print("Creating empty user-item matrix")
num_users = max([r[0] for movie_ratings in ratings.values() for r in movie_ratings])
num_items = len(ratings)
batch_size = 1000
num_batches = (num_items + batch_size - 1)
user_item_matrix = np.zeros((num_users, num_items), dtype=np.float32)

# Step 4: Populate user-item matrix in batches
print("Populating user-item matrix...")
for movie_num, movie_ratings in ratings.items():
    movie_col = movie_num - 1
    for user_rating in movie_ratings:
        user_id, rating = user_rating
        user_row = user_id - 1
        user_item_matrix[user_row][movie_col] = rating
    if movie_num % 100 == 0: # print progress every 100 movies
        print("Processed", movie_num, "movies")

print("Converting user-item matrix to NumPy array with dtype=object and replacing empty strings with None in batches...")
num_batches = (num_users + batch_size - 1) // batch_size
for i in range(num_batches):
    start = i * batch_size
    end = min((i + 1) * batch_size, num_users)
    batch_user_item_matrix = np.array(user_item_matrix[start:end], dtype='object')
    batch_user_item_matrix[batch_user_item_matrix == ''] = None
    batch_user_item_matrix = batch_user_item_matrix.astype(np.float32)
    user_item_matrix[start:end] = batch_user_item_matrix

sparse_matrix = csr_matrix(user_item_matrix)
# save the sparse matrix to a file
save_npz(f'combined_data_4.npz', sparse_matrix)



# Load the saved CSR matrix from the file
saved_sparse_matrix = sp.load_npz(f'combined_data_4.npz')

# Compare the saved matrix with the original matrix
if (saved_sparse_matrix != sparse_matrix).nnz == 0:
    print("The CSR matrix was saved and loaded correctly!")
else:
    print("There was an error loading the CSR matrix from the file.")
'''
'''
# Load the matrices from the files
matrix1 = sp.load_npz('combined_data_1.npz')
matrix2 = sp.load_npz('combined_data_2.npz')
matrix3 = sp.load_npz('combined_data_3.npz')
matrix4 = sp.load_npz('combined_data_4.npz')

# Determine the maximum number of columns
max_cols = max(matrix1.shape[1], matrix2.shape[1], matrix3.shape[1], matrix4.shape[1])

# Add extra columns of zeros to matrices with fewer columns
matrix1 = sp.hstack([matrix1, sp.csr_matrix((matrix1.shape[0], max_cols - matrix1.shape[1]))])
matrix2 = sp.hstack([matrix2, sp.csr_matrix((matrix2.shape[0], max_cols - matrix2.shape[1]))])
matrix3 = sp.hstack([matrix3, sp.csr_matrix((matrix3.shape[0], max_cols - matrix3.shape[1]))])
matrix4 = sp.hstack([matrix4, sp.csr_matrix((matrix4.shape[0], max_cols - matrix4.shape[1]))])

# Combine the matrices vertically
combined_matrix = sp.vstack([matrix1, matrix2, matrix3, matrix4])

# Save the combined matrix to a file
sp.save_npz('combined_data_matrix.npz', combined_matrix)
'''

combined_matrix = sp.load_npz('combined_data_matrix.npz')

print(combined_matrix.shape)
