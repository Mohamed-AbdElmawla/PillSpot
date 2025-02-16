import { useState } from "react";
import { Row, Col, Drawer } from "antd";
import { withTranslation } from "react-i18next";
import { TFunction } from "i18next";
import Container from "../../UI/Container";
import { SvgIcon } from "../../UI/SvgIcon";
import { Button } from "../../UI/Button";
import {
  HeaderSection,
  LogoContainer,
  Burger,
  NotHidden,
  Menu,
  CustomNavLinkSmall,
  Label,
  Outline,
  Span,
} from "./styles";

const Header = ({ t }: { t: TFunction }) => {
  const [visible, setVisibility] = useState(false);

  const toggleButton = () => {
    setVisibility(!visible);
  };

  const MenuItem = () => {
    const scrollTo = (id: string) => {
      const element = document.getElementById(id) as HTMLDivElement;
      element.scrollIntoView({
        behavior: "smooth",
      });
      setVisibility(false);
    };
    return (
      <>
     
          <CustomNavLinkSmall onClick={() => scrollTo("about")}>
            <Span>{t("About")}</Span>
          </CustomNavLinkSmall>
          <CustomNavLinkSmall onClick={() => scrollTo("searchSection")}>
            <Span>{t("Search")}</Span>
          </CustomNavLinkSmall>
          <CustomNavLinkSmall
            style={{ width: "180px" }}
            onClick={() => scrollTo("contact")}
          >
            <Span>
              <Button>{t("Contact")}</Button>
            </Span>
          </CustomNavLinkSmall>
       
      </>
    );
  };

  return (
    <HeaderSection>
      <Container>
        <Row justify="space-between">
          <div className="">
            <LogoContainer to="/" aria-label="homepage">
              <h3>Pill&nbsp;</h3>
              <SvgIcon src="location.svg" width="60px" height="70px" />
              <h3>&nbsp;Spot</h3>
            </LogoContainer>
          </div>
          <NotHidden>
            <MenuItem />
          </NotHidden>
          <Burger onClick={toggleButton}>
            <Outline />
          </Burger>
        </Row>
        <Drawer closable={false} open={visible} onClose={toggleButton}>
          <Col style={{ marginBottom: "2.5rem" }}>
            <Label onClick={toggleButton}>
              <Col span={12}>
                <Menu>Menu</Menu>
              </Col>
              <Col span={12}>
                <Outline />
              </Col>
            </Label>
          </Col>
          <MenuItem />
        </Drawer>
      </Container>
    </HeaderSection>
  );
};

export default withTranslation()(Header);
