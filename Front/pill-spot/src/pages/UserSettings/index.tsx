
import React from 'react';
import { Flex, Layout } from 'antd';
import UserSettingsMain from './MainPage';


const { Header, Sider, Content } = Layout;

const headerStyle: React.CSSProperties = {
  textAlign: 'center',
  color: '#fff',
  height: 64,
  paddingInline: 48,
  lineHeight: '64px',
  backgroundColor: '#4096ff',
};

const contentStyle: React.CSSProperties = {
  color: '#000',
  backgroundColor: '#fff',
};

const siderStyle: React.CSSProperties = {
  textAlign: 'center',
  lineHeight: '120px',
  color: '#fff',
  backgroundColor: '#1677ff',
  overflow : 'hidden' ,
};





const UserSettingPage: React.FC = () => (
  <Flex gap="middle" wrap>
    <Layout className='flex h-screen overflow-hidden'>
      <Sider width="5%" style={siderStyle}>
        Sider
      </Sider>
      <Layout>
        <Header style={headerStyle}>Header</Header>
        <Content style={contentStyle} className='p-5'>
          <UserSettingsMain/>
        </Content>
      </Layout>
    </Layout>
  </Flex>
);

export default UserSettingPage;

// const UserSettingMain = () => {
//   return (
//     <div className="bg-red-100 w-full h-screen flex flex-col">
//       {/* 
//       sideBar
//       topBar  */}

//       {/* outlit */}

//       <div className="flex bg-blue-500 p-5">
//           top-bar
//       </div>
      
//       <div className="flex bg-green-500 px-5">
//           side-bar
//       </div>





      
//     </div>
//   );
// };

// export default UserSettingMain;
