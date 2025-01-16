import csv
import numpy as np
from scipy.sparse import csr_matrix, save_npz
import scipy as sp

def process_batch(batch_lines):
    batch_ratings = {}
    for line in batch_lines:
        line = line.strip()
        if line.endswith(':'):
            movie_num = int(line[:-1])
            batch_ratings[movie_num] = []
        else:
            user_id, rating, rating_date = line.strip().split(',')
            user_id = int(user_id)
            rating = float(rating)
            batch_ratings[movie_num].append((user_id, rating, rating_date))
    return batch_ratings

# Step 1: Load movie data from CSV file
print("Loading movie data from csv file...")
movies = {}
with open('movie_titles.csv', 'r', encoding = "windows-1252") as f:
    reader = csv.reader(f)
    next(reader) # skip header
    for row in reader:
        movie_num = int(row[0])
        movie_year = int(row[1]) if row[1] != "NULL" else 0
        movie_name = row[2]
        movies[movie_num] = {'name': movie_name, 'year': movie_year}

# Step 2: Load rating data from text file in batches
print("Loading rating data from text file in batches...")
batch_size = 1000000 # number of lines to read at a time
ratings = {}
with open('combined_data_1.txt', 'r') as f:
    while True:
        batch = []
        for line in f:
            line = line.strip()
            if line.endswith(':'):
                movie_num = int(line[:-1])
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
user_item_matrix = np.empty((num_users, num_items), dtype=np.float32)

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
save_npz('sparse_matrix.npz', sparse_matrix)