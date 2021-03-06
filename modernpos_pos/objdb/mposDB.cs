﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.objdb
{
    public class mPosDB
    {
        ConnectDB conn;

        public StaffDB stfDB;
        public FSexDB sexDB;
        public CompanyDB copDB;
        public FPrefixDB fpfDB;
        public DepartmentDB deptDB;
        public PositionDB posiDB;
        public AreaDB areaDB;
        public TableDB tblDB;
        public RestaurantDB resDB;
        public FoodsCatDB foocDB;
        public FoodsTypeDB footDB;
        public FoodsDB fooDB;
        public FoodsCatSubDB fcbDB;
        public FoodsRecommendDB foorDB;
        public OrderDB ordDB;
        public BillDB bilDB;
        public BillDetailDB bildDB;
        public sequenceDB seqDB;
        public FoodsSpecialDB foosDB;
        public FoodsToppingDB footpDB;
        public NoodleMakeDB noomDB;
        public OrderToppingDB ordtDB;
        public OrderSpecialDB ordSpecDB;
        public MaterialDB matDB;
        public FoodsMaterialDB foomDB;
        public MaterialTypeDB mattDB;
        public OrderMaterialDB ordmDB;
        public UnitDB unitDB;
        public MaterialRecDB matrDB;
        public MaterialRecDetailDB matrdDB;
        public MaterialDrawDB matdDB;
        public MaterialDrawDetailDB matddDB;
        public StockCardDB stkDB;
        public CloseDayDB cldDB;
        public mPosDB(ConnectDB c)
        {
            conn = c;
            initConfig();            
        }
        private void initConfig()
        {
            Console.WriteLine("mPosDB start");

            stfDB = new StaffDB(conn);
            sexDB = new FSexDB(conn);
            copDB = new CompanyDB(conn);
            deptDB = new DepartmentDB(conn);
            posiDB = new PositionDB(conn);
            fpfDB = new FPrefixDB(conn);
            areaDB = new AreaDB(conn);
            tblDB = new TableDB(conn);
            resDB = new RestaurantDB(conn);
            foocDB = new FoodsCatDB(conn);
            footDB = new FoodsTypeDB(conn);
            //MessageBox.Show("mPosDB middle ", "");
            fooDB = new FoodsDB(conn);
            fcbDB = new FoodsCatSubDB(conn);
            foorDB = new FoodsRecommendDB(conn);
            ordDB = new OrderDB(conn);
            bilDB = new BillDB(conn);
            bildDB = new BillDetailDB(conn);
            seqDB = new sequenceDB(conn);
            foosDB = new FoodsSpecialDB(conn);
            footpDB = new FoodsToppingDB(conn);
            noomDB = new NoodleMakeDB(conn);
            matDB = new MaterialDB(conn);
            foomDB = new FoodsMaterialDB(conn);
            mattDB = new MaterialTypeDB(conn);
            ordmDB = new OrderMaterialDB(conn);
            unitDB = new UnitDB(conn);
            matrDB = new MaterialRecDB(conn);
            matrdDB = new MaterialRecDetailDB(conn);
            matdDB = new MaterialDrawDB(conn);
            matddDB = new MaterialDrawDetailDB(conn);
            stkDB = new StockCardDB(conn);
            cldDB = new CloseDayDB(conn);
            ordtDB = new OrderToppingDB(conn);
            ordSpecDB = new OrderSpecialDB(conn);
            //MessageBox.Show("mPosDB end ", "");
            Console.WriteLine("mPosDB end");
        }
    }
}
