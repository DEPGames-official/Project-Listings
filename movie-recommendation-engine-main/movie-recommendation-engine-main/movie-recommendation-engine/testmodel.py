import scipy.sparse as sp
from sklearn.metrics import mean_squared_error
import tensorflow as tf
import numpy as np

print("Loading saved CSR matrix...")
# Load the saved CSR matrix from the file
test_matrix = sp.load_npz('test_matrix.npz')

print("Loading model...")
# Load model
model = tf.keras.models.load_model("my_model")

# Define batch size
batch_size = 128

# Create a generator that yields batches of the test matrix
def batch_generator(matrix, batch_size):
    num_batches = int(np.ceil(matrix.shape[0] / batch_size))
    for i in range(num_batches):
        print(f"Batch done {i} out of {num_batches}")
        start_idx = i * batch_size
        end_idx = min((i + 1) * batch_size, matrix.shape[0])
        batch_matrix = matrix[start_idx:end_idx]
        if batch_matrix.shape[0] < batch_size:
            # Pad the batch with zeros if it has a size smaller than batch_size
            num_missing = batch_size - batch_matrix.shape[0]
            missing_rows = sp.csr_matrix((num_missing, matrix.shape[1]), dtype=batch_matrix.dtype)
            batch_matrix = sp.vstack([batch_matrix, missing_rows])
        yield batch_matrix
        tf.keras.backend.clear_session()

print("Making predictions...")
predictions = []
for batch_matrix in batch_generator(test_matrix, batch_size):
    batch_predictions = model.predict_on_batch(batch_matrix)
    predictions.append(batch_predictions)
predictions = np.vstack(predictions)

print("Calculating RMSE...")
# Calculate the root mean squared error (RMSE) between the predictions and the actual ratings
actual_ratings = test_matrix.data
rmse = mean_squared_error(actual_ratings, predictions, squared=False)

print("Printing the RMSE...")
# Print the RMSE
print(f"RMSE: {rmse:.4f}")
print(f"Actual ratings: {actual_ratings} Predictions: {predictions}")