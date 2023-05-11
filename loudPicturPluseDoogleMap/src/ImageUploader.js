import React, { useState } from 'react';

export default function ImageUploader() {
  const [selectedFile, setSelectedFile] = useState(null);

  function handleFileUpload(event) {
    setSelectedFile(event.target.files[0]);
    console.log(selectedFile)
  }

  return (
    <div>
      <input type="file" onChange={handleFileUpload} />
      <p>Selected file: {selectedFile && <img src={URL.createObjectURL(selectedFile)} alt="Selected file" />}</p>
    </div>
  );
}
