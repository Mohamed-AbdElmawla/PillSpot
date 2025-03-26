
import React from 'react';
import { Flex, Layout } from 'antd';

import UserSettingHeader from './Header';
import UserSettingSider from './Sider';
import { Outlet } from 'react-router-dom';


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
  top: 0,
  borderRadius: '0 20px 20px 0',
  boxShadow: '0 4px 8px rgba(0, 0, 0, 0.15)', 
};


const UserSettingLayout: React.FC = () => (
  <Flex gap="middle" wrap className='' >
    <Layout className='flex overflow-auto h-[100%]'>
      <Sider width="4vw" style={siderStyle}>
        <UserSettingSider/>
      </Sider>
      <Layout>
        <Header style={headerStyle}> <UserSettingHeader/> </Header>
        <Content style={contentStyle} className='px-4'>
          <Outlet/>
        </Content>
      </Layout>
    </Layout>
  </Flex>
);

export default UserSettingLayout;
