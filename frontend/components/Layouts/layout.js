import Head from 'next/head'

import Header from '../Header/Header'

export default function Layout({ children }) {
    
    return (
      <>
      <Head>
        <title>İkinci Bilet</title>
        <meta name="description" content="Generated by create next app" />
        <link rel="icon" href="/favicon.ico" />
      </Head>
        <main className="w-full h-full p-0 m-0">
            <Header/>
            {children}
        </main>
      </>
    )
  }