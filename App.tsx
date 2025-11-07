
import React from 'react';
import LoginPage from './components/LoginPage';

const App: React.FC = () => {
  return (
    <main className="bg-gray-50 dark:bg-gray-900 min-h-screen flex items-center justify-center p-4 font-sans antialiased">
      <LoginPage />
    </main>
  );
};

export default App;
