import { useEffect, useState } from "react";

function App() {
  const originalText = "7EI3qJg4eBde6GkQ8h06Kg==";
  const finalText = "Decodificador";
  const [tituloCodificado, setTituloCodificado] = useState(originalText);
  let currentIndex = 0;
  let lastIndex = originalText.length - 1;

  useEffect(() => {
    const interval = setInterval(() => {
      if (
        currentIndex <= originalText.length ||
        currentIndex <= finalText.length
      ) {
        let randomIndex = Math.floor(Math.random() * originalText.length);

        let nextText =
          finalText.substring(0, currentIndex) +
          originalText.substring(currentIndex);

        setTituloCodificado(nextText);

        currentIndex++;
      } else {
        clearInterval(interval);
      }
    }, 3000 / (originalText.length + finalText.length));

    return () => clearInterval(interval);
  }, []);

  const autoResize = (e: any) => {
    e.target.style.height = "inherit";
    e.target.style.height = `${e.target.scrollHeight}px`;
  };

  return (
    <div className="w-screen h-screen flex flex-col justify-center items-center">
      <h1 className="text-emerald-600 text-4xl font-bold border-b-2 border-emerald-800 mb-10">
        {tituloCodificado}
      </h1>
      <main className="flex mx-auto gap-10">
        <section className="flex flex-col justify-center items-center">
          <h2 className="text-2xl resize-none font-bold text-slate-300 mb-4">
            Digite seu texto codificado
          </h2>
          <textarea
            rows={1}
            onChange={autoResize}
            className="shadow-md focus-visible:outline-none overflow-y-hidden resize-none box-border p-5 w-96 rounded-lg"
          />
        </section>
        {/* <section className="flex flex-col justify-center items-center">
          <h2 className="focus-visible:outline-none text-2xl font-bold text-emerald-600">Resultado</h2>
          <textarea className="w-96 disabled resize-none h-96 border-2 rounded-lg" />
        </section> */}
      </main>
    </div>
  );
}

export default App;
