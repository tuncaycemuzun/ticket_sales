import Layout from "../components/Layouts/layout";
import {ImSearch,ImLocation} from 'react-icons/Im'
export default function Home() {
  return (
    <Layout>
      <div className="bg-main h-screen pt-28 px-44">
        <div className="flex h-full flex-col items-center justify-center gap-y-6">
          <div className="text-5xl font-medium">Make Your Dream Come True</div>
          <div className="text-4xl">
            Meet your favorite artists, sport teams and parties
          </div>
          <div className="flex justify-center relative items-center">
            <input
              type="text"
              placeholder="Search Artist, Team or Venue"
              className="focus:bg-yellow-300 transition-all font-bold w-96 h-16 rounded-xl outline-none px-4 bg-transparent border-2 border-white text-white placeholder-white"
            />
            <ImSearch className="absolute text-white cursor-pointer text-2xl right-4 font-bold"/>
          </div>
          <div className="flex items-center gap-x-4 text-xl">
            <div>
              <ImLocation className="text-white"/>
            </div>
            <div className="text-white font-bold">
              İstanbul
            </div>
            <div className="underline text-sm cursor-pointer">
              Change Location
            </div>
          </div>
        </div>
      </div>
    </Layout>
  );
}
