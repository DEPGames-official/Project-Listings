import numpy as np
import scipy.sparse as sp
import tensorflow as tf
from sklearn.model_selection import train_test_split


print("Loading the saved CSR matrix from the file...")
# Load the saved CSR matrix from the file
saved_sparse_matrix = sp.load_npz('sparse_matrix.npz')

print("Converting sparse matrix to dense matrix...")
# Convert sparse matrix to dense matrix
dense_matrix = saved_sparse_matrix.toarray()

print("setting training indices...")
train_indices, val_indices = train_test_split(np.arange(dense_matrix.shape[0]), train_size=0.8)

print("Loading new training data...")
# Load new training data
x_train = dense_matrix[train_indices]
y_train = dense_matrix[train_indices]

print("Loading saved model...")
# Load the saved model
model = tf.keras.models.load_model('my_model')

print("Compiling model...")
# Compile the model if needed
model.compile(optimizer='adam', loss='mse', metrics=['accuracy'])

print("Training model on the new data...")
# Train the model on the new data
model.fit(x_train, y_train, epochs=40, batch_size=128)

val_loss = model.evaluate(dense_matrix[val_indices], dense_matrix[val_indices])
print("Validation Loss: ", val_loss)

model.save('my_model(mse)')