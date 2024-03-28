import React, { useState, FormEvent } from 'react';

interface UrlCreatorProps {}

const UrlCreator: React.FC<UrlCreatorProps> = () => {
  const [url, setUrl] = useState<string>('');

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const response = await fetch('http://localhost:5023/api/CreateShortenedUrl/' + encodeURIComponent(url), {
        method: 'POST',
      });

      if (!response.ok) {
        // Handle non-successful response (status code not in 200-299 range)
        throw new Error('Failed to create shortened URL');
      }

      const data = await response.text(); // Assuming the response is a string
      console.log(data);
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        value={url}
        onChange={(e) => setUrl(e.target.value)}
        placeholder="Enter URL"
      />
      <button type="submit">Submit</button>
    </form>
  );
};

export default UrlCreator;
