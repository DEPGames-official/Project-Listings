import numpy as np
import scipy.sparse as sp
import tensorflow as tf
from sklearn.model_selection import train_test_split

import matplotlib.pyplot as plt
from tensorflow import keras
from tensorflow.python.keras.callbacks import ModelCheckpoint, TensorBoard

print("Loading the saved CSR matrix from the file...")
# Load the saved CSR matrix from the file
saved_sparse_matrix = sp.load_npz('sparse_matrix.npz')

print("Converting sparse matrix to dense matrix...")
# Convert sparse matrix to dense matrix
dense_matrix = saved_sparse_matrix.toarray()
print(dense_matrix.shape)

for i in range(dense_matrix.shape[0]):
    print(dense_matrix[:, i])

print("Splitting the dataset into training and testing sets...")
# Split the dataset into training and testing sets
train_indices, val_indices = train_test_split(np.arange(dense_matrix.shape[0]), train_size=0.8)

print("Setting up the checkpoint callback to save the model weights at the end of each epoch...")
# Set up the checkpoint callback to save the model weights at the end of each epoch
checkpoint_callback = ModelCheckpoint('model_weights.h5', save_weights_only=True)

print("Setting up the TensorBoard callback to log training and validation metrics...")
# Set up the TensorBoard callback to log training and validation metrics
log_dir = 'logs'
tensorboard_callback = TensorBoard(log_dir=log_dir, histogram_freq=1, update_freq=10)

print("Defining the neural network architecture...")
# Define the neural network architecture
model = tf.keras.Sequential([
    tf.keras.layers.Input(shape=(dense_matrix.shape[1],)),
    tf.keras.layers.Dense(256, activation='relu'),
    tf.keras.layers.Dense(128, activation='relu'),
    tf.keras.layers.Dense(64, activation='relu'),
    tf.keras.layers.Dense(dense_matrix.shape[1], activation='linear')
])

print("Compiling the model...")
# Compile the model
model.compile(loss='mse', optimizer='adam')

print("Training the model in batches...")
# Train the model in batches
batch_size = 32
num_epochs = 50


for epoch in range(num_epochs):
    print(f"Epoch {epoch + 1}/{num_epochs}")

    # Shuffle the training data at the beginning of each epoch
    np.random.shuffle(train_indices)

    for i in range(0, len(train_indices), batch_size):
        batch_indices = train_indices[i:i + batch_size]
        batch_data = dense_matrix[batch_indices]

        # Train on the current batch
        model.train_on_batch(batch_data, batch_data)
        print(f"Busy with {epoch + 1}/{num_epochs}\n"
              f"Busy with {i} in training_indices out of {len(train_indices)}")

    # Evaluate on the validation set at the end of each epoch
    model.save('my_model')
    val_loss = model.evaluate(dense_matrix[val_indices], dense_matrix[val_indices])
    print(f"Validation loss: {val_loss}")




print("Saving the trained model...")
# Save the trained model
model.save('my_model')

print("Plotting the training and validation loss...")
# Plot the training and validation loss
plt.plot(model.history['loss'])
plt.plot(model.history['val_loss'])
plt.title('Model loss')
plt.ylabel('Loss')
plt.xlabel('Epoch')
plt.legend(['Train', 'Val'], loc='upper right')
plt.show()
