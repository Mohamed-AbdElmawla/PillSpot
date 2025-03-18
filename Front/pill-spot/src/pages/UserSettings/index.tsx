
import React from 'react';
import { Flex, Layout } from 'antd';
import UserSettingsMain from './MainPage';
import UserSettingHeader from './Header';
import UserSettingSider from './Sider';

const { Header, Sider, Content } = Layout;

const headerStyle: React.CSSProperties = {
  textAlign: 'center',
  height: 100,
  paddingInline: 48,
  lineHeight: '64px',
  backgroundColor: '#fff',
  display : 'flex'
};

const contentStyle: React.CSSProperties = {
  color: '#000',
  backgroundColor: '#fff',
};

const siderStyle: React.CSSProperties = {
  textAlign: 'center',
  backgroundColor: '#fff',
  overflow: 'auto',
  height: '100vh',
  position: 'sticky',
  top : 0 ,
};

const UserSettingPage: React.FC = () => (
  <Flex gap="middle" wrap className='' >
    <Layout className='flex overflow-auto h-[100%]'>
      <Sider width="5%" style={siderStyle}>
        <UserSettingSider/>
      </Sider>
      <Layout>
        <Header style={headerStyle}> <UserSettingHeader/> </Header>
        <Content style={contentStyle} className='px-4'>
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
