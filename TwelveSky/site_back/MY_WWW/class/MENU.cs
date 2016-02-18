﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public class MENU
{
    public static string getPageTItle(string TITL, string SUB_TITL)
    {
        string resultStr = null;

        ArrayList menu = MENU.getAdminMenu(TITL);
        for (int i = 0; i < menu.Count; i++)
        {
            string[] _menu = menu[i].ToString().Split(',');
            if (_menu[0].Trim().Equals(SUB_TITL))
            {
                resultStr = _menu[2].Trim();
            }
        }

        return resultStr;
    }
    public static ArrayList getMenu(string TITL)
    {
        ArrayList resultList = new ArrayList();
        string menu1, menu2, menu3, menu4, menu5 = null;
        string menu6, menu7, menu8, menu9, menu10 = null;
        string menu11, menu12, menu13, menu14 = null;

        switch (TITL)
        {
            case "News":
                menu1 = "announcement,  /web/news/announcement.aspx,   Announcements";
                menu2 = "notice,        /web/news/notice.aspx,         Notice";

                resultList.Add(menu1);
                resultList.Add(menu2);
                break;

            case "Game Guides":
                menu1 = "story,         /web/guide/story.aspx,              Story";
                menu2 = "introduction,  /web/guide/introduction.aspx,       Introduction";
                menu3 = "feature,       /web/guide/feature.aspx,            Game Feature";
                menu4 = "requirements,  /web/guide/requirements.aspx,       System Requirements";
                menu5 = "questions,     /web/guide/questions.aspx,          General Questions";
                menu6 = "start,         /web/guide/start.aspx,              Getting Started";
                menu7 = "info,          /web/guide/info.aspx,               Class Info";
                menu8 = "play,          /web/guide/play.aspx,               Game Play";
                menu9 = "pet,           /web/guide/pet.aspx,                Pet Information";
                menu10 = "item,         /web/guide/item.aspx,               Items";
                menu11 = "pvp,          /web/guide/pvp.aspx,                PvP Combat";
                menu12 = "player,       /web/guide/player.aspx,             Player Interaction";
                menu13 = "government,   /web/guide/government.aspx,         Government";
                menu14 = "npcs,         /web/guide/npcs.aspx,               NPCs";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                resultList.Add(menu4);
                resultList.Add(menu5);
                resultList.Add(menu6);
                resultList.Add(menu7);
                resultList.Add(menu8);
                resultList.Add(menu9);
                resultList.Add(menu10);
                resultList.Add(menu11);
                resultList.Add(menu12);
                resultList.Add(menu13);
                resultList.Add(menu14);
                break;

            case "Community":
                menu1 = "discussion,    /web/community/list.aspx?DIV=discussion,     General Discussion";
                menu2 = "tips,          /web/community/list.aspx?DIV=tips,           Tips / Knowhow";
                menu3 = "problem,       /web/community/list.aspx?DIV=problem,        Problem Solution";
                menu4 = "trade,         /web/community/list.aspx?DIV=trade,          Item Trade";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                resultList.Add(menu4);
                break;

            case "Media":
                menu1 = "video,         /web/media/video.aspx,                          Video";
                menu2 = "artwork,       /web/media/list.aspx?DIV=artwork,            Artwork";
                menu3 = "screenshots,   /web/media/list.aspx?DIV=screenshots,        Screenshots";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                break;
        }

        return resultList;
    }

    public static ArrayList getAdminMenu(string TITL)
    {
        ArrayList resultList = new ArrayList();
        string menu1, menu2, menu3, menu4 = null;

        switch (TITL)
        {
            case "Main":
                menu1 = "main_image, /admin/main/main_image.aspx, Main Image";
                menu2 = "main_movie, /admin/main/main_movie.aspx, Main Movie";
                menu3 = "main_banner, /admin/main/main_banner.aspx, Main Banner";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                break;

            case "News":
                menu1 = "announcement,  /admin/news/list.aspx?DIV=announcement,   Announcements";
                menu2 = "notice,        /admin/news/list.aspx?DIV=notice,         Notice";

                resultList.Add(menu1);
                resultList.Add(menu2);
                break;

            case "Community":
                menu1 = "discussion,    /admin/community/list.aspx?DIV=discussion,     General Discussion";
                menu2 = "tips,          /admin/community/list.aspx?DIV=tips,           Tips / Knowhow";
                menu3 = "problem,       /admin/community/list.aspx?DIV=problem,        Problem Solution";
                menu4 = "trade,         /admin/community/list.aspx?DIV=trade,          Item Trade";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                resultList.Add(menu4);
                break;

            case "Media":
                menu1 = "video,         /admin/media/video.aspx,                          Video";
                menu2 = "artwork,       /admin/media/list.aspx?DIV=artwork,            Artwork";
                menu3 = "screenshots,   /admin/media/list.aspx?DIV=screenshots,        Screenshots";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                break;

            case "Shop":
                menu1 = "upgrading,     /admin/shop/list.aspx?DIV=upgrading,        Upgrading";
                menu2 = "buffs,         /admin/shop/list.aspx?DIV=buffs,            Buffs";
                menu3 = "vanity,        /admin/shop/list.aspx?DIV=vanity,           Vanity";
                menu4 = "miscellaeous,  /admin/shop/list.aspx?DIV=miscellaeous,     Miscellaeous";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                resultList.Add(menu4);
                break;

            case "Support":
                menu1 = "questions,     /admin/support/list.aspx,                   Contatct Us";
                menu2 = "code,         /admin/support/code/list.aspx,               Category Type";

                resultList.Add(menu1);
                resultList.Add(menu2);
                break;

            case "User":
                menu1 = "user,  /admin/user/list.aspx, User Admin";
                menu2 = "password, /admin/user/password.aspx, Password Change";
                menu3 = "stat,  /admin/user/stat.aspx, Signup User Count";

                resultList.Add(menu1);
                resultList.Add(menu2);
                resultList.Add(menu3);
                break;
        }

        return resultList;
    }
}